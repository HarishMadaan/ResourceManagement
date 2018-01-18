using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.BDC.Interfaces
{
    public interface IApplicationUserBusiness : IDisposable
    {
        object GetLoginUser(LoginUserModel Logininfo);

        OperationStatus SaveApplicationUser(ApplicationUserModel applicationUserModel);
    }
}
