using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;
using Resource.DAL.Interfaces;

namespace Resource.DAL.Repositories
{
    public class SprintRepo : ISprintRepo
    {
        ResourceManagementEntities dbcontext = null;
        Response response;

        public object GetProjectSprintListing(int ProjectId)
        {
            List<SprintCustomModel> SprintListModel = new List<SprintCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        SprintListModel = dbcontext.tblProjectSprints.Where(x => x.ProjectId == ProjectId)
                            .Select(x => new SprintCustomModel
                            {
                                ProjectId = x.ProjectId,
                                Title = x.Title,
                                Description = x.Description,
                                SprintNo = x.SprintNo,
                                Status = x.Status,
                                SprintId = x.SprintId,
                                StartDate = x.StartDate,
                                EndDate = x.EndDate,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,

                            }).OrderByDescending(x => x.SprintId).ToList();

                        return SprintListModel;

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

        public OperationStatus AddNewSprint(SprintCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (model.SprintId == 0)
                    {
                        var rs = dbcontext.tblProjectSprints.FirstOrDefault(x => x.Title == model.Title && x.ProjectId == model.ProjectId);
                        if (rs == null)
                        {
                            tblProjectSprint _addSprint = new tblProjectSprint
                            {
                                ProjectId = model.ProjectId,
                                Title = model.Title,
                                Description = model.Description,
                                SprintNo = model.SprintNo,
                                Status = model.Status,                               
                                StartDate = model.StartDate,
                                EndDate = model.EndDate,
                                IsActive = true,
                                IsDeleted = false,
                                CreatedDate = DateTime.Now,
                                CreatedBy = model.CreatedBy,
                                ModifiedDate = DateTime.Now,
                                ModifiedBy = model.ModifiedBy,

                            };
                            dbcontext.tblProjectSprints.Add(_addSprint);
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

        public OperationStatus DeleteSprint(int SprintId)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    if (SprintId != 0)
                    {
                        var rs = dbcontext.tblProjectSprints.FirstOrDefault(x => x.SprintId == SprintId);
                        if (rs != null)
                        {
                            dbcontext.tblProjectSprints.Remove(rs);
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
