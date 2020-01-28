using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
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
                it.CreateMap<ApplicantViewModel, Applicant>();
                it.CreateMap<AddressViewModel, Address>();
            });

            var mapper = configuration.CreateMapper();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<PaladinDbContext>().InstancePerRequest();

            builder.RegisterInstance(mapper);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}