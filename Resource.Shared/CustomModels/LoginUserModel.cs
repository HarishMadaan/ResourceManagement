using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Shared.CustomModels
{
    public class LoginUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }
        public int ApplicationUserId { get; set; }
        public bool IsMobile { get; set; }
        
    }
}
