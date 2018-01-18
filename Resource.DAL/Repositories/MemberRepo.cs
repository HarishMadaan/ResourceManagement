using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Shared.CustomModels;
using Resource.DAL.Interfaces;
using System.Net.Mail;

namespace Resource.DAL.Repositories
{
    public class MemberRepo : IMemberRepo
    {
        ResourceManagementEntities dbcontext = null;
        Response response;

        public object GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            IList<MemberCustomModel> MemberListModel = new List<MemberCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        MemberListModel = dbcontext.tblMembers.Where(x => x.IsDeleted == false)
                            .Select(x => new MemberCustomModel
                            {
                                MemberId = x.MemberId,
                                FName = x.FName,
                                LName = x.LName,
                                MemberCode = x.MemberCode,
                                EmailId = x.EmailId,
                                MobileNo = x.MobileNo,
                                MotherName = x.MotherName,
                                FatherName = x.FatherName,
                                Address = x.Address,
                                DateOfBirth = x.DateOfBirth,
                                Designation = x.Designation,
                                UserTypeId = x.UserTypeId,
                                Gender = x.Gender,
                                Image = x.Image,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,

                            }).OrderByDescending(x => x.MemberId).ToList();

                        return MemberListModel;

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

        public object GetMemberDetail(int MemberId)
        {
            using (response = new Response())
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        var rs = dbcontext.tblMembers.Where(x => x.IsDeleted == false && x.MemberId == MemberId)
                            .Select(x => new MemberCustomModel
                            {
                                MemberId = x.MemberId,
                                FName = x.FName,
                                LName = x.LName,
                                MemberCode = x.MemberCode,
                                EmailId = x.EmailId,
                                MobileNo = x.MobileNo,
                                MotherName = x.MotherName,
                                FatherName = x.FatherName,
                                Address = x.Address,
                                DateOfBirth = x.DateOfBirth,
                                Gender = x.Gender,
                                Designation = x.Designation,
                                UserTypeId = x.UserTypeId,
                                Image = x.Image,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,

                                SprintList = x.tblSprintMemberAssociations.Where(s => s.MemberId == x.MemberId).Select(s => new SprintDetail { SprintName = s.tblProjectSprint != null ? s.tblProjectSprint.Title : "" }).ToList(),

                            }).OrderByDescending(x => x.MemberId).ToList();

                        return rs;

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

        public object GetMemberProfile(int MemberId)
        {
            using (response = new Response())
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        var rs = dbcontext.tblMembers.Where(x => x.IsDeleted == false && x.MemberId == MemberId)
                            .Select(x => new MemberCustomModel
                            {
                                MemberId = x.MemberId,
                                FName = x.FName,
                                LName = x.LName,
                                MemberCode = x.MemberCode,
                                EmailId = x.EmailId,
                                MobileNo = x.MobileNo,
                                MotherName = x.MotherName,
                                FatherName = x.FatherName,
                                Address = x.Address,
                                DateOfBirth = x.DateOfBirth,
                                Gender = x.Gender,
                                Designation = x.Designation,
                                UserTypeId = x.UserTypeId,
                                Image = x.Image,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,

                                ProjectList = x.tblProjectMemberAssociations.Where(s => s.MemberId == x.MemberId).Select(s => new ProjectDetail { ProjectName = s.tblProject != null ? s.tblProject.Title : "" }).ToList(),

                            }).OrderByDescending(x => x.MemberId).ToList();

                        return rs;

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

        public OperationStatus ForgotPassword(ForgotPasswordCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    var rs = dbcontext.tblApplicationUsers.FirstOrDefault(x => x.UserName == model.UserName);
                    if (rs != null)
                    {
                        string from = "madaan.harish08@gmail.com"; //any valid GMail ID  
                        string to = Convert.ToString(rs.EmailId); //any valid GMail ID  
                        using (MailMessage mail = new MailMessage(from, to))
                        {
                            mail.Subject = "Resource Management Forgot Password";
                            mail.Body = "Dear " + rs.FName +" " + rs.LName+ "  <br><br>Please use this password to login: " + rs.Password + "<br><br>Thanks,<br>Team";

                            mail.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential
                            ("madaan.harish08@gmail.com", "shally123");// Enter seders User name and password 
                            smtp.EnableSsl = true;
                            smtp.Send(mail);

                            status = OperationStatus.Success;
                        }
                    }
                    else
                    {
                        status = OperationStatus.Duplicate;
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
