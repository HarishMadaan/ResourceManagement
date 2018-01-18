using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;
using Resource.BDC.Interfaces;
using Resource.DAL.Interfaces;
using Resource.DAL.Repositories;

namespace Resource.BDC.Classes
{
    public class SprintBusiness : ISprintBusiness
    {
        ISprintRepo _ISprintRepo;

        /// <summary>
        /// This method is used to list all projects
        /// </summary>
        /// <returns></returns>
        public object GetProjectSprintListing(int ProjectId)
        {
            using (_ISprintRepo = new SprintRepo())
            {
                return _ISprintRepo.GetProjectSprintListing(ProjectId);
            }
        }

        /// <summary>
        /// This method is used to add new projects
        /// </summary>
        /// <returns></returns>
        public OperationStatus AddNewSprint(SprintCustomModel model)
        {
            using (_ISprintRepo = new SprintRepo())
            {
                return _ISprintRepo.AddNewSprint(model);
            }
        }

        /// <summary>
        /// This method is used to delete sprint
        /// </summary>
        /// <returns></returns>
        public OperationStatus DeleteSprint(int SprintId)
        {
            using (_ISprintRepo = new SprintRepo())
            {
                return _ISprintRepo.DeleteSprint(SprintId);
            }
        }

        public void Dispose()
        {
            _ISprintRepo.Dispose();
            GC.SuppressFinalize(this);
            // throw new NotImplementedException();
        }
    }
}
