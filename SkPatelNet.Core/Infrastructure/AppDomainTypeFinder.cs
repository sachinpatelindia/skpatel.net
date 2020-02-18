using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SkPatelNet.Core.Infrastructure
{
    public class AppDomainTypeFinder:ITypeFinder
    {
        private bool _ignoreReflectionErrors;

        public AppDomainTypeFinder()
        {
        }

        public bool LoadAppDomainAssemblies { get; set; }

        public IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(typeof(T), onlyConcreteClasses);
        }

        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(assignTypeFrom, GetAssemblies(), onlyConcreteClasses);
        }

        public IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(typeof(T), assemblies, onlyConcreteClasses);
        }

        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses)
        {
            var result = new List<Type>();
            try
            {
                foreach (var a in assemblies)
                {
                    Type[] types = null;
                    try
                    {
                        types = a.GetTypes();
                    }
                    catch
                    {
                        if (_ignoreReflectionErrors)
                        {
                            throw;
                        }
                    }

                    if (types == null)
                        continue;

                    foreach (var t in types)
                    {
                        if (!assignTypeFrom.IsAssignableFrom(t) && (!assignTypeFrom.IsGenericTypeDefinition || !DoesTypeImplementOpenGeneric(t, assignTypeFrom)))
                            continue;
                        if (t.IsInterface)
                            continue;
                        if(onlyConcreteClasses)
                        {
                            if(t.IsClass && !t.IsAbstract)
                            {
                                result.Add(t);
                            }
                        }
                        else
                        {
                            result.Add(t);
                        }
                    }
                }
            }
            catch(ReflectionTypeLoadException ex)
            {
                var msg = string.Empty;
                foreach (var e in ex.LoaderExceptions)
                    msg += e.Message + Environment.NewLine;
                var fail = new Exception(msg, ex);
                Debug.WriteLine(fail.Message,fail);

                throw fail;
            }
            return result;
        }

        private bool DoesTypeImplementOpenGeneric(Type t, Type assignTypeFrom)
        {
            throw new NotImplementedException();
        }

        public virtual IList<Assembly> GetAssemblies()
        {
            var addedAssemblyNames = new List<string>();
            var assemblies = new List<Assembly>();
            if (LoadAppDomainAssemblies)
                AddAssembliesInAppDomain(addedAssemblyNames,assemblies);
            AddConfiguredAssemblies(addedAssemblyNames,assemblies);
            return assemblies;
        }

        private void AddConfiguredAssemblies(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            throw new NotImplementedException();
        }

        private void AddAssembliesInAppDomain(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            throw new NotImplementedException();
        }
    }
}