using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using Resource.Shared.CustomModels;
using Resource.DAL.Interfaces;

namespace Resource.DAL.Repositories
{
    public class ApplicationUserRepo : IApplicationUserRepo
    {

        ResourceManagementEntities dbcontext = null;
        
        /// <summary>
        /// method is used for validate application users
        /// </summary>
        /// <param name="Logininfo"></param>
        /// <returns></returns>
        public object GetLoginUser(LoginUserModel Logininfo)
        {
            APIResponse _response = new APIResponse();
            LoggedInUserModel lgAppUserDetails = new LoggedInUserModel();
            object objLgAppUserDetails;
            try
            {
                using (dbcontext = new ResourceManagementEntities())
                {
                    Logininfo.UserName = Logininfo.UserName.ToLower();
                    tblApplicationUser lgDetail = dbcontext.tblApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == Logininfo.UserName && x.IsDeleted == false);

                    if (lgDetail != null)
                    {
                        if (lgDetail.Password == Logininfo.Password)
                        {
                            lgAppUserDetails.ApplicationUserId = lgDetail.ApplicationUserId;
                            lgAppUserDetails.UserIdentityKey = lgDetail.UserIdentityKey;
                            lgAppUserDetails.success = true;
                            lgAppUserDetails.ErrorMessage = "User Authenticated!!";
                            lgAppUserDetails.FName = lgDetail.FName == null ? "" : lgDetail.FName;
                            lgAppUserDetails.LName = lgDetail.LName == null ? "" : lgDetail.LName;
                            lgAppUserDetails.MemberCode = lgDetail.MemberCode == null ? "" : lgDetail.MemberCode;
                            lgAppUserDetails.UserTypeId = lgDetail.UserTypeId == null ? 0 : lgDetail.UserTypeId;
                            lgAppUserDetails.UserType = lgDetail.tblUserTypeMaster != null ? lgDetail.tblUserTypeMaster.Title : "";
                            lgAppUserDetails.EmailId = lgDetail.EmailId;
                            lgAppUserDetails.MobileNo = lgDetail.MobileNo;
                            lgAppUserDetails.Address = lgDetail.Address;
                            lgAppUserDetails.Gender = lgDetail.Gender;
                            lgAppUserDetails.DateOfBirth = lgDetail.DateOfBirth;
                            lgAppUserDetails.FatherName = lgDetail.tblMember == null ? "" : lgDetail.tblMember.FatherName;
                            lgAppUserDetails.MotherName = lgDetail.tblMember == null ? "" : lgDetail.tblMember.MotherName;
                            lgAppUserDetails.UserTypeId = lgDetail.UserTypeId;
                            lgAppUserDetails.UserName = lgDetail.UserName;
                            lgAppUserDetails.Designation = lgDetail.tblMember != null ? lgDetail.tblMember.Designation : "";

                            _response.Message = "User Authenticated!!";
                            _response.IsSucess = true;

                        }
                        else
                        {
                            lgAppUserDetails.ErrorMessage = "Invalid password!!";
                            _response.Message = "Invalid password!!";
                            _response.IsSucess = false;
                        }
                    }
                    else
                    {
                        lgAppUserDetails.ErrorMessage = "Invalid username!!";
                        _response.Message = "Invalid username!!";
                        _response.IsSucess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lgAppUserDetails = null;
                objLgAppUserDetails = null;
                dbcontext = null;
                lgAppUserDetails.ErrorMessage = ex.Message.ToString();
            }
            objLgAppUserDetails = lgAppUserDetails;
            return objLgAppUserDetails;
        }


        /// <summary>
        /// This method is used to save new members
        /// </summary>
        /// <returns></returns>
        public OperationStatus SaveApplicationUser(ApplicationUserModel applicationUserModel)
        {
            OperationStatus status = OperationStatus.Error;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    using (dbcontext = new ResourceManagementEntities())
                    {
                        if (applicationUserModel.ApplicationUserId == 0)
                        {
                            var rs = dbcontext.tblApplicationUsers.FirstOrDefault(x => x.UserName == applicationUserModel.UserName && x.IsDeleted == false);
                            if (rs == null)
                            {
                                tblMember _addMember = new tblMember
                                {
                                    FName = applicationUserModel.FName,
                                    LName = applicationUserModel.LName,
                                    MemberCode = applicationUserModel.MemberCode,
                                    UserTypeId = applicationUserModel.UserTypeId,
                                    EmailId = applicationUserModel.EmailId,
                                    MobileNo = applicationUserModel.MobileNo,
                                    Address = applicationUserModel.Address,
                                    Gender = applicationUserModel.Gender,
                                    DateOfBirth = applicationUserModel.DateOfBirth,
                                    FatherName = applicationUserModel.FatherName,
                                    MotherName = applicationUserModel.MotherName,
                                    Designation = applicationUserModel.Designation,

                                    IsActive = true,
                                    IsDeleted = false,
                                    CreatedDate = DateTime.Now,
                                    CreatedBy = applicationUserModel.CreatedBy,
                                    ModifiedDate = DateTime.Now,
                                    ModifiedBy = applicationUserModel.ModifiedBy,

                                };
                                dbcontext.tblMembers.Add(_addMember);
                                dbcontext.SaveChanges();
                                int userid = _addMember.MemberId;

                                tblApplicationUser _applicationUserinfo = new tblApplicationUser
                                {
                                    FName = applicationUserModel.FName,
                                    LName = applicationUserModel.LName,
                                    MemberCode = applicationUserModel.MemberCode,
                                    UserTypeId = applicationUserModel.UserTypeId,
                                    EmailId = applicationUserModel.EmailId,
                                    MobileNo = applicationUserModel.MobileNo,
                                    Address = applicationUserModel.Address,
                                    Gender = applicationUserModel.Gender,
                                    DateOfBirth = applicationUserModel.DateOfBirth,
                                    UserIdentityKey = userid,
                                    UserName = applicationUserModel.UserName,
                                    Password = applicationUserModel.Password,

                                    IsActive = true,
                                    IsDeleted = false,
                                    CreatedDate = DateTime.Now,
                                    CreatedBy = applicationUserModel.CreatedBy,
                                    ModifiedDate = DateTime.Now,
                                    ModifiedBy = applicationUserModel.ModifiedBy,
                                };

                                dbcontext.tblApplicationUsers.Add(_applicationUserinfo);
                                dbcontext.SaveChanges();

                                status = OperationStatus.Success;
                                ts.Complete();
                            }
                            else
                            {
                                status = OperationStatus.Duplicate;
                                //ts.Dispose();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    dbcontext.Dispose();
                    status = OperationStatus.Exception;
                    ts.Dispose();
                    throw ex;
                }
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
