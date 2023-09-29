using System.Collections.Generic;

namespace AccountingApp.Application.Responses.Identity
{
    public class GetAllUsersResponse
    {
        public IEnumerable<UserResponse> Users { get; set; }
    }
}