using System.Collections.Generic;

namespace SkPatelNet.Core.Infrastructure
{
    public interface ISkPatelFileProvider
    {
        bool DirectoryExists(string directoryPath);
        string[] GetFiles(string directoryPath, string searchPattern="",bool topDirectory=true);
    }
}