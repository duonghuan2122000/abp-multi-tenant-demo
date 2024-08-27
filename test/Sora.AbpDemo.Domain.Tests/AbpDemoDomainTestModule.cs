using Volo.Abp.Modularity;

namespace Sora.AbpDemo;

[DependsOn(
    typeof(AbpDemoDomainModule),
    typeof(AbpDemoTestBaseModule)
)]
public class AbpDemoDomainTestModule : AbpModule
{

}
