﻿using Autofac;
using Autofac.Features.Variance;
using MediatR;
using System.Collections.Generic;
using System.Reflection;
using NotowaniaMVC.Application.FuelPrices.Interfaces;
using NotowaniaMVC.Application.FuelPrices.Services;

namespace NotowaniaMVC.Autofac
{
    public static class AutofacConfiguration
    {
        static IContainer container;

        public static IContainer RegisterAndResolve()
        {
            var builder = new ContainerBuilder();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.RegisterType<QuotationService>().As<IQuotationService>().InstancePerLifetimeScope();
            builder.RegisterType<FuelPriceService>().As<IFuelPriceService>().InstancePerLifetimeScope();

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(MediatR.IMediator).Assembly).AsSelf().AsImplementedInterfaces();


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