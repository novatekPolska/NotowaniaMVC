﻿using Autofac;
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
using NotowaniaMVC.Infrastructure.Dictionaries.Repositories;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using NotowaniaMVC.Domain.Quotation.Services;
using NotowaniaMVC.Domain.Quotation.Interfaces;
using NotowaniaMVC.Infrastructure.Common.Repositories;
using NotowaniaMVC.Infrastructure.Common.Interfaces;
using System.Linq;
using System;
using NotowaniaMVC.Infrastructure.Quotations.Repositories;
using NotowaniaMVC.Infrastructure.Quotations.Interfaces; 
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Domain.Documents.Interfaces;
using NotowaniaMVC.Domain.Documents.Helpers;
using NotowaniaMVC.Domain.Documents.Mappers;
using NotowaniaMVC.Domain.Quotations.Mappers;
using NotowaniaMVC.Domain.Documents.Services;

namespace NotowaniaMVC.Autofac
{
    public static class AutofacConfiguration
    {  
        public static IContainer RegisterAndResolve()
        {
            var builder = new ContainerBuilder();
            Configuration cfg = new Configuration();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            DatabaseConfiguration dbConfig = new DatabaseConfiguration();

            builder.RegisterAssemblyTypes(executingAssembly)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register(c => cfg.BuildSessionFactory()).As<ISessionFactory>().SingleInstance();
            builder.Register(c => dbConfig.GetSession());
          //  builder.Register(c => c.Resolve<ISessionFactory>().OpenSession());

            
            builder.RegisterType<FuelPriceService>().As<IFuelPriceService>().InstancePerLifetimeScope();

            builder.RegisterType<QuotationsRepository>().As<IQuotationsRepository>().InstancePerLifetimeScope(); 
            
            builder.RegisterGeneric(typeof(NHibernateUniversalRepository<>)).As(typeof(INHibernateUniversalRepository<>)).OnActivating(e =>
            {
                var typeToLookup = e.Parameters.FirstOrDefault() as TypedParameter;
                if (typeToLookup != null)
                {
                    var respositoryType = typeof(NHibernateUniversalRepository<>);
                    Type[] typeArgs = { typeToLookup.Value.GetType() };
                    var genericType = respositoryType.MakeGenericType(typeArgs);
                    var genericRepository = Activator.CreateInstance(genericType);
                    e.ReplaceInstance(genericRepository);
                }
            }); 
            builder.RegisterType<PriceListsRepository>().As<IPriceListsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FuelTypesRepository>().As<IFuelTypesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<QuotationDomainService>().As<IQuotationDomainService>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentsDomainService>().As<IDocumentsDomainService>().InstancePerLifetimeScope();
            
            builder.RegisterType<QuotationTypesRepository>().As<IQuotationTypesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UnitsRepository>().As<IUnitsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyRepository>().As<ICurrencyRepository>().InstancePerLifetimeScope();

            builder.RegisterType<DbDocumentsHelper>().As<IDbDocumentHelper>().InstancePerLifetimeScope();
            builder.RegisterType<DiskDocumentsHelper>().As<IDiskDocumentHelper>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentToDocumentDbMapper>().As<IDocumentToDocumentDbMapper>().InstancePerLifetimeScope();
            builder.RegisterType<QuotationToQuotationDbMapper>().As<IQuotationToQuotationDbMapper>().InstancePerLifetimeScope();

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsSelf().AsImplementedInterfaces();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(QuotationsCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(QuotationsCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));
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
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container; 
        }

        public static void Shutdown(IContainer container)
        {
            container.Dispose();
        } 
    }
     
}