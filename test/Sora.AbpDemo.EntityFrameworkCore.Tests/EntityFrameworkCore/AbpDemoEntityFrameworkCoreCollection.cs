using Xunit;

namespace Sora.AbpDemo.EntityFrameworkCore;

[CollectionDefinition(AbpDemoTestConsts.CollectionDefinitionName)]
public class AbpDemoEntityFrameworkCoreCollection : ICollectionFixture<AbpDemoEntityFrameworkCoreFixture>
{

}
