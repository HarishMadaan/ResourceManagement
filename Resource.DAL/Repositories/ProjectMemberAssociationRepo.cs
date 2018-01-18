using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;
using Resource.DAL.Interfaces;

namespace Resource.DAL.Repositories
{
    public class ProjectMemberAssociationRepo : IProjectMemberAssociationRepo
    {
        ResourceManagementEntities dbcontext = null;
        Response response;

        public object GetMyProjectList(int MemberId)
        {
            IList<ProjectMemberAssociationCustomModel> ProjectListModel = new List<ProjectMemberAssociationCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    try
                    {
                        if (MemberId != 0)
                        {
                            response.success = true;
                            ProjectListModel = dbcontext.tblProjectMemberAssociations.Where(x => x.MemberId == MemberId && x.IsDeleted == false)
                                .Select(x => new ProjectMemberAssociationCustomModel
                                {
                                    ProjectId = x.ProjectId,
                                    ProjectName = x.tblProject != null ? x.tblProject.Title : "",
                                    MemberId = x.MemberId,
                                    MemberName = x.tblMember != null ? x.tblMember.FName + " " + x.tblMember.LName : "",
                                    Description = x.Description,
                                    Status = x.Status,
                                    StartDate = x.StartDate,
                                    EndDate = x.EndDate,
                                    IsActive = x.IsActive,
                                    IsDeleted = x.IsDeleted,
                                    CreatedBy = x.CreatedBy,
                                    CreatedDate = x.CreatedDate,
                                    ModifiedBy = x.ModifiedBy,
                                    ModifiedDate = x.ModifiedDate,

                                }).OrderByDescending(x => x.ProjectId).ToList();

                            return ProjectListModel;
                        }
                        else
                        {
                            response.success = false;
                            return ProjectListModel;
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

        public OperationStatus AddNewProjectMemberAssociation(ProjectMemberAssociationCustomModel objProjectMemberModel)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (objProjectMemberModel.ProjectMemberAssociationId == 0)
                    {
                        if (objProjectMemberModel.ProjectMemberList != null)
                        {
                            List<tblProjectMemberAssociation> entityKisanLIst = objProjectMemberModel.ProjectMemberList.Select(m => new tblProjectMemberAssociation
                            {
                                ProjectId = objProjectMemberModel.ProjectId,
                                MemberId = m.ProjectMemberId,
                                StartDate = objProjectMemberModel.StartDate,
                                EndDate = objProjectMemberModel.EndDate,
                                Description = objProjectMemberModel.Description,
                                Status = objProjectMemberModel.Status == null ? "1" : objProjectMemberModel.Status,
                                IsActive = true,
                                IsDeleted = false,

                            }).ToList();

                            dbcontext.tblProjectMemberAssociations.AddRange(entityKisanLIst);
                            dbcontext.SaveChanges();
                            status = OperationStatus.Success;
                        }

                        //var rs = dbcontext.tblProjectMemberAssociations.FirstOrDefault(x => x.IsDeleted == false && x.ProjectId == objProjectMemberModel.ProjectId && x.MemberId == objProjectMemberModel.MemberId);
                        //if (rs == null)
                        //{
                        //    tblProjectMemberAssociation _addProjectList = new tblProjectMemberAssociation
                        //    {
                        //        ProjectId = objProjectMemberModel.ProjectId,
                        //        MemberId = objProjectMemberModel.MemberId,
                        //        StartDate = objProjectMemberModel.StartDate,
                        //        EndDate = objProjectMemberModel.EndDate,
                        //        Description = objProjectMemberModel.Description,
                        //        Status = objProjectMemberModel.Status == null ? "1" : objProjectMemberModel.Status,
                        //        IsActive = true,
                        //        IsDeleted = false,
                        //        CreatedBy = objProjectMemberModel.CreatedBy,
                        //        CreatedDate = System.DateTime.Now,
                        //        ModifiedBy = objProjectMemberModel.ModifiedBy,
                        //        ModifiedDate = System.DateTime.Now,
                        //    };
                        //    dbcontext.tblProjectMemberAssociations.Add(_addProjectList);
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

        public OperationStatus DeleteProjectAssociation(int ProjectId)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (ProjectId != 0)
                    {
                        var rs = dbcontext.tblProjectMemberAssociations.FirstOrDefault(x => x.ProjectMemberAssociationId == ProjectId);
                        if (rs != null)
                        {
                            dbcontext.tblProjectMemberAssociations.Remove(rs);
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
