using System;
using AccountingApp.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace AccountingApp.Infrastructure.Models.Identity
{
    public class AccountingAppRoleClaim : IdentityRoleClaim<string>, IAuditableEntity<int>
    {
        public string Description { get; set; }
        public string Group { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual AccountingAppRole Role { get; set; }

        public AccountingAppRoleClaim() : base()
        {
        }

        public AccountingAppRoleClaim(string roleClaimDescription = null, string roleClaimGroup = null) : base()
        {
            Description = roleClaimDescription;
            Group = roleClaimGroup;
        }
    }
}