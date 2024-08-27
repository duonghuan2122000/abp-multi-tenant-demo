using Volo.Abp.Modularity;

namespace Sora.AbpDemo;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpDemoDomainTestBase<TStartupModule> : AbpDemoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
