using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ByteBank.Portal
{
    public sealed class Server : IDisposable
    {
        private readonly HttpListener _listener;

        private readonly ILogger _logger;

        private HttpListenerContext _context;

        private Dictionary<string, Action<HttpListenerRequest, HttpListenerResponse>> _routes;

        public Server(HttpListener listener, ILogger logger)
        {
            _listener = listener;
            _logger = logger;
            _routes = new Dictionary<string, Action<HttpListenerRequest, HttpListenerResponse>>();
        }

        public void Listen(string address)
        {
            _listener.Prefixes.Add(address);

            _listener.Start();

            _logger.Information($"ByteBank is running: {address}");

            _context = _listener.GetContext();

            var route = _context.Request.Url.AbsolutePath;

            if (!_routes.ContainsKey(route))
            {
                return;
            }

            _routes[route](_context.Request, _context.Response);
        }

        public void Get(string url, Action<HttpListenerRequest, HttpListenerResponse> action)
        {
            _routes.Add(url, action);
        }

        public void Static(string url)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resources = from resource in assembly.GetManifestResourceNames()
                            where Regex.IsMatch(resource, @"\.wwwroot.+")
                            let path = Regex.Match(resource, @"\.wwwroot(?<Path>.+)").Groups["Path"].Value
                            let dirname = Regex.Match(path, @"(?<Dirname>^\.\w+\.)").Groups["Dirname"].Value.Replace('.', '/')
                            let filename = Regex.Match(path, @"(?<Filename>\w+\.\w+$)").Groups["Filename"].Value
                            select new
                            {
                                Name = resource,
                                Dirname = dirname,
                                Filename = filename,
                                Url = $"{dirname}{filename}"
                            };

            foreach (var it in resources)
            {
                _routes.Add($"{url}{it.Url}", (req, res) =>
                {
                    var resource = assembly.GetManifestResourceStream(it.Name);

                    var buffer = new byte[resource.Length];

                    resource.Read(buffer, 0, buffer.Length);

                    res.StatusCode = 200;

                    res.ContentType = "text/css";

                    res.ContentLength64 = buffer.Length;

                    res.OutputStream.Write(buffer, 0, buffer.Length);
                });
            }
        }

        public void Dispose()
        {
            _context.Response.OutputStream.Close();

            _listener.Stop();
        }
    }
}
