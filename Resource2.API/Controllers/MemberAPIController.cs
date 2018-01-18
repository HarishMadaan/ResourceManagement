using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Resource.Shared.CustomModels;
using Resource.BDC.Interfaces;
using Resource.BDC.Classes;

namespace Resource2.API.Controllers
{
    public class MemberAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IMemberBusiness memberService;
        #endregion

        public MemberAPIController()
        {

        }

        //public MemberAPIController(MemberBusiness _memberService)
        //{
        //    this.memberService = _memberService;
        //}

        /// <summary>
        /// This method is used to fetch Application Members
        /// </summary>
        /// <returns>List of Application Members</returns>
        [HttpGet]
        [Route("API/MemberAPI/GetApplicationMemberList")]
        public Response GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            _response = new Response();
            try
            {
                MemberBusiness memberService = new MemberBusiness();
                _response.responseData = memberService.GetApplicationMemberList(objMemberModel);
                _response.message = "Records loaded successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                memberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to fetch one Members
        /// </summary>
        /// <returns>List of one Members</returns>
        [HttpGet]
        [Route("API/MemberAPI/GetMemberDetail/{MemberId}")]
        public Response GetMemberDetail(int MemberId)
        {
            _response = new Response();
            try
            {
                MemberBusiness memberService = new MemberBusiness();
                _response.responseData = memberService.GetMemberDetail(MemberId);
                _response.message = "Records loaded successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                memberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to fetch one Member profile
        /// </summary>
        /// <returns>List of one Member profile</returns>
        [HttpGet]
        [Route("API/MemberAPI/GetMemberProfile/{MemberId}")]
        public Response GetMemberProfile(int MemberId)
        {
            _response = new Response();
            try
            {
                MemberBusiness memberService = new MemberBusiness();
                _response.responseData = memberService.GetMemberProfile(MemberId);
                _response.message = "Records loaded successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                memberService = null;
            }
            return _response;
        }


        /// <summary>
        /// This method is used for forgot password
        /// </summary>
        /// <returns>forgot password</returns>
        [HttpPost]
        [Route("API/MemberAPI/ForgotPassword")]
        public Response ForgotPassword(ForgotPasswordCustomModel model)
        {
            _response = new Response();
            try
            {
                MemberBusiness memberService = new MemberBusiness();
                _response.responseData = memberService.ForgotPassword(model);
                _response.message = "Mail Sent Successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                memberService = null;
            }
            return _response;
        }

    }
}
