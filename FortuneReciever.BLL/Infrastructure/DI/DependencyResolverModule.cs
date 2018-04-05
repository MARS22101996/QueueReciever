using Autofac;
using FortuneReceiver.DAL.Interfaces;
using FortuneReceiver.DAL.Repositories;

namespace FortuneReciever.BLL.Infrastructure.DI
{
   public class DependencyResolverModuleBll
   {
      public static void Configure(ContainerBuilder builder)
      {
         builder.RegisterType<AzureServiceBusRepository>().As<IQueueRepository>();
      }
   }
}
