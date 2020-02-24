﻿using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SkPatelNet.Core.Infrastructure
{
    public class AppDomainTypeFinder:ITypeFinder
    {
        private bool _ignoreReflectionErrors = true;
        private readonly IFileProvider _fileProvider;
        public AppDomainTypeFinder(IFileProvider fileProvider=null)
        {
            this._fileProvider = fileProvider ?? CommonHelper.DefaultFileProvider;
        }
        public bool LoadAppDomainAssemblies { get; set; } = true;
        public IList<string> AssemblyNames { get; set; } = new List<string>();
        public string AssemblySkipLoadingPattern { get; set; } = "^System|^netstandard|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease|^SkPatelNet.Web.Views";

        public string AssemblyRestrictToLoadingPattern { get; set; } = ".*";
        public virtual AppDomain App => AppDomain.CurrentDomain;

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

        protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach(var implementedInterface in type.FindInterfaces((objectType,objectCritical)=>true,null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return
                         isMatch;
                }
                return false;
            }
            catch
            {
                return false;
            }
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
           foreach(var assemblyName in AssemblyNames)
            {
                var assembly = Assembly.Load(assemblyName);
                if (addedAssemblyNames.Contains(assembly.FullName))
                    continue;
                assemblies.Add(assembly);
                addedAssemblyNames.Add(assembly.FullName);

            }
        }

        private void AddAssembliesInAppDomain(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!Matches(assembly.FullName))
                    continue;

                if (addedAssemblyNames.Contains(assembly.FullName))
                    continue;
                assemblies.Add(assembly);
                addedAssemblyNames.Add(assembly.FullName);                 
            }
        }

        public virtual bool Matches(string assemblyFullName)
        {
            return !Matches(assemblyFullName, AssemblySkipLoadingPattern) && Matches(assemblyFullName, AssemblyRestrictToLoadingPattern);
        }

        protected virtual bool Matches(string assemblyFullName, string pattern)
        {
            return Regex.IsMatch(assemblyFullName,pattern,RegexOptions.IgnoreCase|RegexOptions.Compiled);
        }

        protected virtual void LoadMatchingAssemblies(string directoryPath)
        {
            var loadedAssemblyNames = new List<string>();
            foreach(var a in GetAssemblies())
            {
                loadedAssemblyNames.Add(a.FullName);
            }
            if(_fileProvider.GetDirectoryContents(directoryPath).Exists)
            {
                return;
            }

            foreach (var dllPath in Directory.GetFiles(directoryPath, "*.dll"))
            {
                try
                {
                    var an = AssemblyName.GetAssemblyName(dllPath);
                    if (Matches(an.FullName) && !loadedAssemblyNames.Contains(an.FullName))
                    {
                        App.Load(an);
                    }
                }
                catch(BadImageFormatException ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
        }
    }

    public class CommonHelper
    {
        public static IFileProvider DefaultFileProvider { get;  set; }
    }
}