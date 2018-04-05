using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using FortuneReciever.BLL.Infrastructure.DI;
using FortuneReciever.BLL.Interfaces;
using FortuneReciever.BLL.Services;
using FortuneReciever.Infrastrucrure.Automapper;

namespace FortuneReciever.Infrastrucrure.DI
{
   public class DependencyResolverModule
   {
      public static void Setup()
      {
         var builder = new ContainerBuilder();

         builder.RegisterControllers(typeof(MvcApplication).Assembly);

         Configure(builder);

         DependencyResolverModuleBll.Configure(builder);

         var container = builder.Build();

         DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      }

      private static void Configure(ContainerBuilder builder)
      {
         builder.Register(c => AutoMapperConfiguration.Configure()).As<IMapper>()
         .InstancePerLifetimeScope().PropertiesAutowired().PreserveExistingDefaults();
         builder.RegisterType<FortuneService>().As<IFortuneService>();
      }
   }
}