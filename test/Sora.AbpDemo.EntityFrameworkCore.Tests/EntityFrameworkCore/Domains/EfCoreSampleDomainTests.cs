using Sora.AbpDemo.Samples;
using Xunit;

namespace Sora.AbpDemo.EntityFrameworkCore.Domains;

[Collection(AbpDemoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpDemoEntityFrameworkCoreTestModule>
{

}
