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
    public class SprintMemberAssociationBusiness : ISprintMemberAssociationBusiness
    {
        ISprintMemberAssociationRepo _ISprintRepo;

        /// <summary>
        /// This method is used to list all Sprints
        /// </summary>
        /// <returns></returns>
        public object GetMySprintList(int MemberId)
        {
            using (_ISprintRepo = new SprintMemberAssociationRepo())
            {
                return _ISprintRepo.GetMySprintList(MemberId);
            }
        }

        /// <summary>
        /// This method is used to add new sprints
        /// </summary>
        /// <returns></returns>
        public OperationStatus AddNewSprintMemberAssociation(SprintMemberAssociationCustomModel objSprintMemberModel)
        {
            using (_ISprintRepo = new SprintMemberAssociationRepo())
            {
                return _ISprintRepo.AddNewSprintMemberAssociation(objSprintMemberModel);
            }
        }

        /// <summary>
        /// This method is used to update sprint status
        /// </summary>
        /// <returns></returns>
        public OperationStatus UpdateSprintStatus(int SprintId, string Status)
        {
            using (_ISprintRepo = new SprintMemberAssociationRepo())
            {
                return _ISprintRepo.UpdateSprintStatus(SprintId, Status);
            }
        }

        /// <summary>
        /// This method is used to delete sprint status
        /// </summary>
        /// <returns></returns>
        public OperationStatus DeleteSprintAssociation(int SprintId)
        {
            using (_ISprintRepo = new SprintMemberAssociationRepo())
            {
                return _ISprintRepo.DeleteSprintAssociation(SprintId);
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
