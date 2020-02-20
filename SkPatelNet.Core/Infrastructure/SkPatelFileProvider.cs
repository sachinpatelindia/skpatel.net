using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SkPatelNet.Core.Infrastructure
{
    public class SkPatelFileProvider : PhysicalFileProvider, ISkPatelFileProvider
    {
        public SkPatelFileProvider(IHostingEnvironment hostingEnvironment) : base(File.Exists(hostingEnvironment.WebRootPath)?Path.GetDirectoryName(hostingEnvironment.WebRootPath):hostingEnvironment.WebRootPath)
        {
            var path = hostingEnvironment.ContentRootPath ?? string.Empty;
            if (File.Exists(path))
                path = Path.GetDirectoryName(path);
            BaseDirectory = path;
        }

        protected string BaseDirectory { get; }

        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public string[] GetFiles(string directoryPath, string searchPattern = "", bool topDirectory = true)
        {
            if (string.IsNullOrEmpty(searchPattern))
                searchPattern = "*.*";
            return Directory.GetFiles(directoryPath,searchPattern,topDirectory?SearchOption.TopDirectoryOnly:SearchOption.AllDirectories);
        }
    }
}
