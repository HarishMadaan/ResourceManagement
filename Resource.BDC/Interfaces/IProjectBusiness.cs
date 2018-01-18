using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.BDC.Interfaces
{
    public interface IProjectBusiness : IDisposable
    {
        object GetProjectListing(ProjectCustomModel objProjectModel);
        OperationStatus AddNewProject(ProjectCustomModel objProjectModel);
        OperationStatus DeleteProject(int ProjectId);
    }
}
