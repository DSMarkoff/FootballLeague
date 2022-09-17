﻿using FootballLeague.Containers.Abstraction;
using SimpleInjector;

namespace FootballLeague.Containers.Initializer
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize(Container container)
        {
            var packages = new IPackage[]
            {

            };

            foreach (var package in packages)
            {
                package.RegisterServices(container);
            }
        }
    }
}