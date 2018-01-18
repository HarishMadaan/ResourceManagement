using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.BDC.Interfaces
{
    public interface IMemberBusiness : IDisposable
    {
        object GetApplicationMemberList(MemberCustomModel objMemberModel);

        object GetMemberDetail(int MemberId);
        object GetMemberProfile(int MemberId);
        OperationStatus ForgotPassword(ForgotPasswordCustomModel model);
    }
}
