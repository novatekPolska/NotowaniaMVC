using Autofac;
using Autofac.Features.Variance;
using MediatR;
using System.Collections.Generic;
using System.Reflection;
using NotowaniaMVC.Application.FuelPrices.Interfaces;
using NotowaniaMVC.Application.FuelPrices.Services;
using NotowaniaMVC.Infrastructure.FuelPrices.Interfaces;
using NotowaniaMVC.Infrastructure.FuelPrices.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NotowaniaMVC.Infrastructure.Quotations.Repositories;
using NotowaniaMVC.Infrastructure.Quotations.Interfaces;

namespace NotowaniaMVC.Autofac
{
    public static class AutofacConfiguration
    {
        static IContainer container;

        public static IContainer RegisterAndResolve()
        {
            var builder = new ContainerBuilder();
            Configuration cfg = new Configuration();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register(c => cfg.BuildSessionFactory()).As<ISessionFactory>().SingleInstance();
            builder.Register(c => c.Resolve<ISessionFactory>().OpenSession());

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder.RegisterType<QuotationService>().As<IQuotationService>().InstancePerLifetimeScope();
            builder.RegisterType<FuelPriceService>().As<IFuelPriceService>().InstancePerLifetimeScope();

            builder.RegisterType<QuotationsRepository>().As<IQuotationsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PriceListsRepository>().As<IPriceListsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FuelTypesRepository>().As<IFuelTypesRepository>().InstancePerLifetimeScope();

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsSelf().AsImplementedInterfaces();


            builder
              .Register<SingleInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => { object o; return c.TryResolve(t, out o) ? o : null; };
              })
              .InstancePerLifetimeScope();

            builder
              .Register<MultiInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
              })
              .InstancePerLifetimeScope();
            
            var container = builder.Build();

            return container; 
        }

        public static void Shutdown()
        {
            container.Dispose();
        } 
    }
}