using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.BDC.Interfaces
{
    public interface ISprintMemberAssociationBusiness : IDisposable
    {
        object GetMySprintList(int MemberId);

        OperationStatus AddNewSprintMemberAssociation(SprintMemberAssociationCustomModel objSprintMemberModel);

        OperationStatus UpdateSprintStatus(int SprintId, string Status);

        OperationStatus DeleteSprintAssociation(int SprintId);
    }
}
