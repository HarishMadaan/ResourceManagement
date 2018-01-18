using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.DAL.Interfaces
{
    public interface IProjectMemberAssociationRepo : IDisposable
    {
        object GetMyProjectList(int MemberId);

        OperationStatus AddNewProjectMemberAssociation(ProjectMemberAssociationCustomModel objProjectMemberModel);

        OperationStatus DeleteProjectAssociation(int ProjectId);
    }
}
