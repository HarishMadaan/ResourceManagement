using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;
using Resource.DAL.Interfaces;

namespace Resource.DAL.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        ResourceManagementEntities dbcontext = null;
        Response response;

        public object GetProjectListing(ProjectCustomModel objProjectModel)
        {
            IList<ProjectCustomModel> ProjectListModel = new List<ProjectCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        ProjectListModel = dbcontext.tblProjects.Where(x => x.IsDeleted == false)
                            .Select(x => new ProjectCustomModel
                            {
                                ProjectId = x.ProjectId,
                                Title = x.Title,
                                Description = x.Description,
                                Documents = x.Documents,
                                Image = x.Image,
                                AlliasName = x.AlliasName,
                                ProjectType = x.ProjectType,                                
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
                    catch (Exception ex)
                    {
                        response.success = false;
                        response.message = ex.Message;
                        return response;
                    }
                }
            }
        }

        public OperationStatus AddNewProject(ProjectCustomModel objProjectModel)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (objProjectModel.ProjectId == 0)
                    {
                        var rs = dbcontext.tblProjects.FirstOrDefault(x => x.Title == objProjectModel.Title && x.IsDeleted == false);
                        if (rs == null)
                        {
                            tblProject _addProject = new tblProject
                            {
                                Title = objProjectModel.Title,
                                Description = objProjectModel.Description,
                                Documents = objProjectModel.Documents,
                                Image = objProjectModel.Image,
                                AlliasName = objProjectModel.AlliasName,
                                ProjectType = objProjectModel.ProjectType,
                                StartDate = objProjectModel.StartDate,
                                EndDate = objProjectModel.EndDate,
                                IsActive = true,
                                IsDeleted = false,
                                CreatedDate = DateTime.Now,
                                CreatedBy = objProjectModel.CreatedBy,
                                ModifiedDate = DateTime.Now,
                                ModifiedBy = objProjectModel.ModifiedBy,

                            };
                            dbcontext.tblProjects.Add(_addProject);
                            dbcontext.SaveChanges();

                            status = OperationStatus.Success;
                        }
                        else
                        {
                            status = OperationStatus.Duplicate;
                        }
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

        public OperationStatus DeleteProject(int ProjectId)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (ProjectId != 0)
                    {
                        var rs = dbcontext.tblProjects.FirstOrDefault(x => x.ProjectId == ProjectId);
                        if (rs != null)
                        {
                            dbcontext.tblProjects.Remove(rs);
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
