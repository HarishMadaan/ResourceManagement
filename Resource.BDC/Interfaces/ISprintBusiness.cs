using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.BDC.Interfaces
{
    public interface ISprintBusiness : IDisposable
    {
        object GetProjectSprintListing(int ProjectId);
        OperationStatus AddNewSprint(SprintCustomModel model);
        OperationStatus DeleteSprint(int SprintId);
    }
}
