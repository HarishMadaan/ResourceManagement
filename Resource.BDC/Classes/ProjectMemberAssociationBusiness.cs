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
    public class ProjectMemberAssociationBusiness : IProjectMemberAssociationBusiness
    {
        IProjectMemberAssociationRepo _IProjectMemberRepo;

        /// <summary>
        /// this method is used to get my project list
        /// </summary>
        /// <returns></returns>
        public object GetMyProjectList(int MemberId)
        {
            using (_IProjectMemberRepo = new ProjectMemberAssociationRepo())
            {
                return _IProjectMemberRepo.GetMyProjectList(MemberId);
            }
        }

        /// <summary>
        /// this method is used to add new projects member association
        /// </summary>
        /// <returns></returns>
        public OperationStatus AddNewProjectMemberAssociation(ProjectMemberAssociationCustomModel objProjectMemberModel)
        {
            using (_IProjectMemberRepo = new ProjectMemberAssociationRepo())
            {
                return _IProjectMemberRepo.AddNewProjectMemberAssociation(objProjectMemberModel);
            }
        }

        /// <summary>
        /// this method is used to delete projects member association
        /// </summary>
        /// <returns></returns>
        public OperationStatus DeleteProjectAssociation(int ProjectId)
        {
            using (_IProjectMemberRepo = new ProjectMemberAssociationRepo())
            {
                return _IProjectMemberRepo.DeleteProjectAssociation(ProjectId);
            }
        }

        public void Dispose()
        {
            _IProjectMemberRepo.Dispose();
            GC.SuppressFinalize(this);
            // throw new NotImplementedException();
        }
    }
}
