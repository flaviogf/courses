using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
using Serilog;
using System.Web.Mvc;

namespace Paladin.Web
{
    public class ContainerConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var configuration = new MapperConfiguration(it =>
            {
                it.CreateMap<ApplicantViewModel, Applicant>().ReverseMap();
                it.CreateMap<AddressViewModel, Address>().ReverseMap();
                it.CreateMap<EmploymentViewModel, Employement>().ReverseMap();
                it.CreateMap<VehicleViewModel, Vehicle>().ReverseMap();
                it.CreateMap<ProductViewModel, Product>().ReverseMap();
            });

            IMapper mapper = configuration.CreateMapper();

            ILogger logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<PaladinDbContext>().InstancePerRequest();

            builder.RegisterInstance(mapper);

            builder.RegisterInstance(logger);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}