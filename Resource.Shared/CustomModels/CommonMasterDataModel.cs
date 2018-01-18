using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Shared.CustomModels
{
    public class CommonMasterDataModel
    {
        
    }

    public enum OperationStatus
    {
        Exception = -1,
        Error = 0,
        Success = 1,
        Duplicate = 2,
        MailSent = 3,
        UsernameChanged = 4,
        CompanyInactive = 5,
        UserInactive = 6,
        SessionExpired = 7,
        Deleted = 8,
        EmailExists = 9,
        MailFailure = 10,
        StartEndDate = 11,
        ReceiptNoduplicate = 12,
        DependendentRecord = 13,
        PasswardNotMatch = 14,
        InvalidParameter = 15,
        ACantBeGreaterThanB = 16,

    }

}
