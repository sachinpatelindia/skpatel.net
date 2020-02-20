using System;
using System.Collections.Generic;
using System.Reflection;

namespace SkPatelNet.Core.Infrastructure
{
    public interface ITypeFinder
    {

        public IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);

        public IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

        public IEnumerable<Type> FindClassesOfType(Type assignFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses);
        IList<Assembly> GetAssemblies();
    }
}
