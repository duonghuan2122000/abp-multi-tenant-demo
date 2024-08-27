using Sora.AbpDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sora.AbpDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpDemoEntityFrameworkCoreModule),
    typeof(AbpDemoApplicationContractsModule)
)]
public class AbpDemoDbMigratorModule : AbpModule
{
}
