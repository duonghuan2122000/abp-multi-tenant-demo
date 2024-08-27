using Sora.AbpDemo.Samples;
using Xunit;

namespace Sora.AbpDemo.EntityFrameworkCore.Applications;

[Collection(AbpDemoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpDemoEntityFrameworkCoreTestModule>
{

}
