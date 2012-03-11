﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Collections;

namespace Application.Controller.Resolver
{
    public class ResolveDependency : System.Web.Http.Services.IDependencyResolver
    {
        private readonly IContainer _container;
        public ResolveDependency(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            return _container.IsRegistered(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            Type enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            object instance = _container.Resolve(enumerableServiceType);
            return ((IEnumerable)instance).Cast<object>();
        }
    }
}