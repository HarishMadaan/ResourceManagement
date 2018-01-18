﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.DAL.Interfaces
{
    public interface IMemberRepo : IDisposable
    {
        object GetApplicationMemberList(MemberCustomModel objMemberModel);
        object GetMemberDetail(int MemberId);

        object GetMemberProfile(int MemberId);
        OperationStatus ForgotPassword(ForgotPasswordCustomModel model);
    }
}
