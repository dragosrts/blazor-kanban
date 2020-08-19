using System.Collections.Generic;

namespace BlazorKanban.Shared
{
    public class UserInfoParameters
    {
        public bool IsAuthenticated { get; set; }

        public string UserName { get; set; }

        public Dictionary<string, string> ExposedClaims { get; set; }
    }
}