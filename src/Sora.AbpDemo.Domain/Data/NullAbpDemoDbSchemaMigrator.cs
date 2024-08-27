﻿using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sora.AbpDemo.Data;

/* This is used if database provider does't define
 * IAbpDemoDbSchemaMigrator implementation.
 */
public class NullAbpDemoDbSchemaMigrator : IAbpDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
