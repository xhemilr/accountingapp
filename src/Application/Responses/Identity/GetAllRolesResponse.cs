using System.Collections.Generic;

namespace AccountingApp.Application.Responses.Identity
{
    public class GetAllRolesResponse
    {
        public IEnumerable<RoleResponse> Roles { get; set; }
    }
}