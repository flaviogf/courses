using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AluraCar.Dto;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AluraCar.Service
{
    public static class LoginService
    {
        public static async Task Autenticar(LoginRequest login)
        {
            try
            {
                var cliente = new HttpClient { BaseAddress = new Uri("http://aluracar.herokuapp.com") };
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", login.Email),
                    new KeyValuePair<string, string>("senha", login.Senha),
                });
                var response = await cliente.PostAsync("/login", content);
                var json = await response.Content.ReadAsStringAsync();
                var body = JsonConvert.DeserializeObject<LoginResponse>(json);
                if (response.IsSuccessStatusCode)
                {
                    MessagingCenter.Send(body.Usuario, "SuccessLogin");
                    return;
                }
                throw new HttpRequestException("ErrorLogin");
            }
            catch (HttpRequestException exception)
            {
                MessagingCenter.Send(exception, "ErrorLogin");
            }
        }
    }
}
