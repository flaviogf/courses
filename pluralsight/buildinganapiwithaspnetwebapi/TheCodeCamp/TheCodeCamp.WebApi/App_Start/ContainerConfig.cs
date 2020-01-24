using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System.Reflection;
using System.Web.Http;
using TheCodeCamp.WebApi.Models;
using TheCodeCamp.WebApi.Repositories;
using TheCodeCamp.WebApi.ViewModels;

namespace TheCodeCamp.WebApi
{
    public class ContainerConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TheCodeCampContext>().InstancePerRequest();

            builder.RegisterType<EntityFrameworkCampRepository>().As<ICampRepository>().InstancePerRequest();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Camp, CampViewModel>()
                   .ForMember(it => it.Venue, mo => mo.MapFrom(it => it.Location.VenueName))
                   .ReverseMap();

                cfg.CreateMap<Talk, TalkViewModel>()
                   .ReverseMap()
                   .ForMember(it => it.Id, mo => mo.Ignore())
                   .ForMember(it => it.Speaker, mo => mo.Ignore())
                   .ForMember(it => it.Camp, mo => mo.Ignore());

                cfg.CreateMap<Speaker, SpeakerViewModel>()
                   .ReverseMap();
            });

            var mapper = mapperConfiguration.CreateMapper();

            builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}