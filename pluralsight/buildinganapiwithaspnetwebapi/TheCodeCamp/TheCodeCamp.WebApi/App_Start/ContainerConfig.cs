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
                   .ForMember(it => it.Venue, mo => mo.MapFrom(it => it.Location.VenueName));

                cfg.CreateMap<Talk, TalkViewModel>();

                cfg.CreateMap<Speaker, SpeakerViewModel>();
            });

            var mapper = mapperConfiguration.CreateMapper();

            builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}