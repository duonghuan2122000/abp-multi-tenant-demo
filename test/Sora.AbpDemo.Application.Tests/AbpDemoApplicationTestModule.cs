using Volo.Abp.Modularity;

namespace Sora.AbpDemo;

[DependsOn(
    typeof(AbpDemoApplicationModule),
    typeof(AbpDemoDomainTestModule)
)]
public class AbpDemoApplicationTestModule : AbpModule
{

}
