using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.DAL.Interfaces
{
    public interface IProjectRepo : IDisposable
    {
        object GetProjectListing(ProjectCustomModel objProjectModel);
        OperationStatus AddNewProject(ProjectCustomModel objProjectModel);
        OperationStatus DeleteProject(int ProjectId);
    }
}
