using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.DAL.Interfaces
{
    public interface IApplicationUserRepo : IDisposable
    {
        object GetLoginUser(LoginUserModel Logininfo);
        OperationStatus SaveApplicationUser(ApplicationUserModel user);
    }
}
