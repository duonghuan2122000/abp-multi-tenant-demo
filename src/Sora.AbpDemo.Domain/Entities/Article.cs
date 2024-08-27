using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Sora.AbpDemo.Entities
{
    public partial class Article : Entity<string>, IMultiTenant
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public partial class Article : Entity<string>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
    }
}