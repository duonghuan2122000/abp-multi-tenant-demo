using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace Sora.AbpDemo
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(ITenantAppService), typeof(AbpDemoTenantAppService))]
    public class AbpDemoTenantAppService : TenantAppService
    {
        public AbpDemoTenantAppService(ITenantRepository tenantRepository, ITenantManager tenantManager, IDataSeeder dataSeeder, IDistributedEventBus distributedEventBus, ILocalEventBus localEventBus) : base(tenantRepository, tenantManager, dataSeeder, distributedEventBus, localEventBus)
        {
        }

        [Authorize(TenantManagementPermissions.Tenants.Create)]
        public override async Task<TenantDto> CreateAsync(TenantCreateDto input)
        {
            var tenant = await TenantManager.CreateAsync(input.Name);
            input.MapExtraPropertiesTo(tenant);

            using (var uow = UnitOfWorkManager.Begin(new Volo.Abp.Uow.AbpUnitOfWorkOptions { IsTransactional = false }, requiresNew: true))
            {
                await TenantRepository.InsertAsync(tenant);
                await uow.CompleteAsync();
            }

            var connectionString = $"Server=localhost;Port=3306;Database=sora_demo_{tenant.Id.ToString("N")};Uid=root;Pwd=0866444202;";

            using (CurrentTenant.Change(tenant.Id, tenant.Name))
            {
                using (var uow = UnitOfWorkManager.Begin(new Volo.Abp.Uow.AbpUnitOfWorkOptions { IsTransactional = false }, requiresNew: true))
                {
                    await UpdateDefaultConnectionStringAsync(tenant.Id, connectionString);
                    await uow.CompleteAsync();
                }

                //TODO: Handle database creation?
                // TODO: Seeder might be triggered via event handler.
                //await DataSeeder.SeedAsync(
                //                new DataSeedContext(tenant.Id)
                //                    .WithProperty("AdminEmail", input.AdminEmailAddress)
                //                    .WithProperty("AdminPassword", input.AdminPassword)
                //                );
            }

            await DistributedEventBus.PublishAsync(
                new TenantCreatedEto
                {
                    Id = tenant.Id,
                    Name = tenant.Name,
                    Properties =
                    {
                        { "AdminEmail", input.AdminEmailAddress },
                        { "AdminPassword", input.AdminPassword }
                    }
                });

            return ObjectMapper.Map<Tenant, TenantDto>(tenant);
        }
    }
}