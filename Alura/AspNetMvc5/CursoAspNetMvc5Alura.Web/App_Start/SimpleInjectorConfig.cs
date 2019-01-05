using CursoAspNetMvc5Alura.Application;
using CursoAspNetMvc5Alura.Application.Intefaces;
using CursoAspNetMvc5Alura.Data;
using CursoAspNetMvc5Alura.Data.Repositories;
using CursoAspNetMvc5Alura.Domain.Interfaces.Repositories;
using CursoAspNetMvc5Alura.Domain.Interfaces.Services;
using CursoAspNetMvc5Alura.Domain.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

namespace CursoAspNetMvc5Alura.Web.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void Inicializa()
        {
            var container = new Container();
            container.Register(typeof(CursoAspNetMvc5AluraContext));
            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<IClienteService, ClienteService>();
            container.Register<IClienteApplication, ClienteApplication>();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
