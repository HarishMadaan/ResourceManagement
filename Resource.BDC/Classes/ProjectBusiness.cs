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
    public class ProjectBusiness : IProjectBusiness
    {
        IProjectRepo _IProjectRepo;

        /// <summary>
        /// This method is used to list all projects
        /// </summary>
        /// <returns></returns>
        public object GetProjectListing(ProjectCustomModel objProjectModel)
        {
            using (_IProjectRepo = new ProjectRepo())
            {
                return _IProjectRepo.GetProjectListing(objProjectModel);
            }
        }

        /// <summary>
        /// This method is used to add new projects
        /// </summary>
        /// <returns></returns>
        public OperationStatus AddNewProject(ProjectCustomModel objProjectModel)
        {
            using (_IProjectRepo = new ProjectRepo())
            {
                return _IProjectRepo.AddNewProject(objProjectModel);
            }
        }

        /// <summary>
        /// This method is used to delete projects
        /// </summary>
        /// <returns></returns>
        public OperationStatus DeleteProject(int ProjectId)
        {
            using (_IProjectRepo = new ProjectRepo())
            {
                return _IProjectRepo.DeleteProject(ProjectId);
            }
        }

        public void Dispose()
        {
            _IProjectRepo.Dispose();
            GC.SuppressFinalize(this);
            // throw new NotImplementedException();
        }
    }
}
