using AutoMapper;
using CursoAspNetMvc5Alura.Domain.Models;
using CursoAspNetMvc5Alura.Web.ViewModels;

namespace CursoAspNetMvc5Alura.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Inicializa()
        {
            Mapper.Initialize(it =>
            {
                it.CreateMap<Cliente, ClienteViewModel>();
                it.CreateMap<ClienteViewModel, Cliente>();
            });
        }
    }
}