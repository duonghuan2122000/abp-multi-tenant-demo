using System.Threading.Tasks;

namespace Sora.AbpDemo.Data;

public interface IAbpDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
