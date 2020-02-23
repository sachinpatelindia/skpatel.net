using Microsoft.EntityFrameworkCore;

namespace SkPatelNet.Data.Mapping
{
    public partial interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
