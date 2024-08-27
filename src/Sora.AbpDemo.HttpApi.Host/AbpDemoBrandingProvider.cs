using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Sora.AbpDemo;

[Dependency(ReplaceServices = true)]
public class AbpDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpDemo";
}
