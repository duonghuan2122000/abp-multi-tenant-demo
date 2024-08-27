using Volo.Abp.Modularity;

namespace Sora.AbpDemo;

public abstract class AbpDemoApplicationTestBase<TStartupModule> : AbpDemoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
