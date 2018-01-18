using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;
using Resource.DAL.Interfaces;

namespace Resource.DAL.Repositories
{
    public class SprintMemberAssociationRepo : ISprintMemberAssociationRepo
    {
        ResourceManagementEntities dbcontext = null;
        Response response;

        public object GetMySprintList(int MemberId)
        {
            List<SprintMemberAssociationCustomModel> SprintListModel = new List<SprintMemberAssociationCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    try
                    {
                        if (MemberId != 0)
                        {
                            response.success = true;
                            SprintListModel = dbcontext.tblSprintMemberAssociations.Where(x => x.MemberId == MemberId && x.IsDeleted == false)
                                .Select(x => new SprintMemberAssociationCustomModel
                                {                                    
                                    SprintMemberAssociationId = x.SprintMemberAssociationId,
                                    SprintId = x.SprintId,
                                    SprintName = x.tblProjectSprint != null ? x.tblProjectSprint.Title : "",
                                    MemberId = x.MemberId,
                                    MemberName = x.tblMember != null ? x.tblMember.FName + " " + x.tblMember.LName : "",
                                    Description = x.Description,
                                    StartDate = x.StartDate,
                                    EndDate = x.EndDate,
                                    Status = x.Status,
                                    IsActive = x.IsActive,

                                }).OrderByDescending(x => x.SprintMemberAssociationId).ToList();

                            return SprintListModel;
                        }
                        else
                        {
                            response.success = false;
                            return SprintListModel;
                        }
                    }
                    catch (Exception ex)
                    {
                        response.success = false;
                        response.message = ex.Message;
                        return response;
                    }
                }
            }
        }

        public OperationStatus AddNewSprintMemberAssociation(SprintMemberAssociationCustomModel objSprintMemberModel)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (objSprintMemberModel.SprintMemberAssociationId == 0)
                    {
                        if (objSprintMemberModel.SprintMemberList != null)
                        {
                            List<tblSprintMemberAssociation> entitySprintLIst = objSprintMemberModel.SprintMemberList.Select(m => new tblSprintMemberAssociation
                            {
                                SprintId = objSprintMemberModel.SprintId,
                                MemberId = m.SprintMemberId,
                                StartDate = objSprintMemberModel.StartDate,
                                EndDate = objSprintMemberModel.EndDate,
                                Description = objSprintMemberModel.Description,
                                Status = objSprintMemberModel.Status == null ? "1" : objSprintMemberModel.Status,
                                IsActive = true,
                                IsDeleted = false,

                            }).ToList();

                            dbcontext.tblSprintMemberAssociations.AddRange(entitySprintLIst);
                            dbcontext.SaveChanges();
                            status = OperationStatus.Success;
                        }

                        //var rs = dbcontext.tblSprintMemberAssociations.FirstOrDefault(x => x.IsDeleted == false && x.SprintId == objSprintMemberModel.SprintId && x.MemberId == objSprintMemberModel.MemberId);
                        //if (rs == null)
                        //{
                        //    tblSprintMemberAssociation _addSprintist = new tblSprintMemberAssociation
                        //    {
                        //        SprintId = objSprintMemberModel.SprintId,
                        //        MemberId = objSprintMemberModel.MemberId,
                        //        StartDate = objSprintMemberModel.StartDate,
                        //        EndDate = objSprintMemberModel.EndDate,
                        //        Description = objSprintMemberModel.Description,
                        //        Status = objSprintMemberModel.Status == null ? "1" : objSprintMemberModel.Status,
                        //        IsActive = true,
                        //        IsDeleted = false,
                        //        CreatedBy = objSprintMemberModel.CreatedBy,
                        //        CreatedDate = System.DateTime.Now,
                        //        ModifiedBy = objSprintMemberModel.ModifiedBy,
                        //        ModifiedDate = System.DateTime.Now,
                        //    };
                        //    dbcontext.tblSprintMemberAssociations.Add(_addSprintist);
                        //    dbcontext.SaveChanges();

                        //    status = OperationStatus.Success;
                        //}
                        //else
                        //{
                        //    status = OperationStatus.Duplicate;
                        //}
                    }
                    else
                    {
                        status = OperationStatus.Error;
                    }
                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                status = OperationStatus.Exception;
                throw ex;
            }

            return status;
        }

        public OperationStatus UpdateSprintStatus(int SprintId, string Status)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (SprintId != 0)
                    {
                        var rs = dbcontext.tblSprintMemberAssociations.FirstOrDefault(x => x.SprintMemberAssociationId == SprintId);
                        if (rs != null)
                        {
                            rs.Status = Status;
                            dbcontext.SaveChanges();
                            status = OperationStatus.Success;
                        }
                    }
                    else
                    {
                        status = OperationStatus.Error;
                    }
                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                status = OperationStatus.Exception;
                throw ex;
            }

            return status;
        }

        public OperationStatus DeleteSprintAssociation(int SprintId)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (SprintId != 0)
                    {
                        var rs = dbcontext.tblSprintMemberAssociations.FirstOrDefault(x => x.SprintMemberAssociationId == SprintId);
                        if (rs != null)
                        {
                            dbcontext.tblSprintMemberAssociations.Remove(rs);
                            dbcontext.SaveChanges();
                            status = OperationStatus.Success;
                        }
                    }
                    else
                    {
                        status = OperationStatus.Error;
                    }
                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                status = OperationStatus.Exception;
                throw ex;
            }

            return status;
        }

        public void Dispose()
        {
            dbcontext.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }

    }
}
