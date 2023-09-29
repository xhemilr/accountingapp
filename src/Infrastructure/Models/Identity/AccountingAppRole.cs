using System;
using System.Collections.Generic;
using AccountingApp.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace AccountingApp.Infrastructure.Models.Identity
{
    public class AccountingAppRole : IdentityRole, IAuditableEntity<string>
    {
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual ICollection<AccountingAppRoleClaim> RoleClaims { get; set; }

        public AccountingAppRole() : base()
        {
            RoleClaims = new HashSet<AccountingAppRoleClaim>();
        }

        public AccountingAppRole(string roleName, string roleDescription = null) : base(roleName)
        {
            RoleClaims = new HashSet<AccountingAppRoleClaim>();
            Description = roleDescription;
        }
    }
}