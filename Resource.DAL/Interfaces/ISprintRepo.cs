using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;

namespace Resource.DAL.Interfaces
{
    public interface ISprintRepo : IDisposable
    {
        object GetProjectSprintListing(int ProjectId);
        OperationStatus AddNewSprint(SprintCustomModel model);
        OperationStatus DeleteSprint(int SprintId);
    }
}
