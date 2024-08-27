using Sora.AbpDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Sora.AbpDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpDemoController : AbpControllerBase
{
    protected AbpDemoController()
    {
        LocalizationResource = typeof(AbpDemoResource);
    }
}
