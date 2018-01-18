using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Resource.Shared.CustomModels;
using Resource.BDC.Interfaces;
using Resource.BDC.Classes;


namespace Resource.API.Controllers
{
    public class AccountAPIController : ApiController
    {
        #region Global Variable
        // APIResponse _response = new APIResponse();
        Response _response = new Response();
        
        private IApplicationUserBusiness applicationUserService;

        #endregion

        public AccountAPIController()
        {

        }

        public AccountAPIController(ApplicationUserBusiness _applicationUserService)
        {
            this.applicationUserService = _applicationUserService;
        }
        

        [Route("api/ApplicationAPI/Hello")]
        public string Hello()
        {
            return "Hello Word API";
        }

        /// <summary>
        /// Function is used for login user.
        /// </summary>
        /// <returns>Object of APIResponse</returns>   
        [HttpPost]
        [Route("API/AccountAPI/GetLoginUser")]
        public object GetLoginUser(LoginUserModel users)
        {
            IApplicationUserBusiness applicationUserService = new ApplicationUserBusiness();
            return applicationUserService.GetLoginUser(users);

            //_response = new Response();            
            //try
            //{
            //    IApplicationUserBusiness applicationUserService = new ApplicationUserBusiness();
            //    _response.responseData = applicationUserService.GetLoginUser(users);
            //    //_response.message = _response.Message;
            //    //_response.success = _response.IsSucess;
            //}
            //catch (Exception ex)
            //{
            //    _response.success = false;
            //    _response.message = ex.Message.ToString();
            //}
            //finally
            //{
            //    applicationUserService = null;
            //}
            //return _response;
        }

        /// <summary>
        /// Function is used for login user.
        /// </summary>
        /// <returns>Object of APIResponse</returns>   
        [HttpPost]
        [Route("API/AccountAPI/SaveApplicationUser")]
        public Response SaveApplicationUser(ApplicationUserModel applicationUserModel)
        {
            _response = new Response();
            try
            {
                IApplicationUserBusiness applicationUserService = new ApplicationUserBusiness();
                _response.responseData = applicationUserService.SaveApplicationUser(applicationUserModel);
                //_response.message = "User Save successfully !!";
                //_response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                applicationUserService = null;
            }
            return _response;
        }

    }
}
