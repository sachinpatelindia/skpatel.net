using System;
using System.Collections.Generic;
using System.Reflection;

namespace SkPatelNet.Core.Infrastructure
{
    public class WebAppTypeFinder:AppDomainTypeFinder
    {
        private bool _binFolderAssembliesLoaded;

        public bool EnsureBinFolderAssembliesLoaded { get; set; } = true;

        public WebAppTypeFinder()
        {
        }

        public virtual string GetBinDirectory()
        {
            return AppContext.BaseDirectory;
        }
        public override IList<Assembly> GetAssemblies()
        {
            if (!EnsureBinFolderAssembliesLoaded || _binFolderAssembliesLoaded)
                return base.GetAssemblies();

            _binFolderAssembliesLoaded = true;
            var binPath = GetBinDirectory();
            LoadMatchingAssemblies(binPath);
            return base.GetAssemblies();
        }

        private void LoadMatchingAssemblies(string binPath)
        {
            throw new NotImplementedException();
        }
    }
}