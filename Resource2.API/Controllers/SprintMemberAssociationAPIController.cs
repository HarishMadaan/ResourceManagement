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
    public class SprintMemberAssociationAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private ISprintMemberAssociationBusiness SprintMemberService;
        #endregion

        public SprintMemberAssociationAPIController()
        {

        }

        public SprintMemberAssociationAPIController(SprintMemberAssociationBusiness _SprintMemberService)
        {
            this.SprintMemberService = _SprintMemberService;
        }

        /// <summary>
        /// This method is used to fetch Sprint list
        /// </summary>
        /// <returns>List of Projects</returns>
        [HttpGet]
        [Route("API/SprintMemberAssociationAPI/GetMySprintList/{MemberId}")]
        public Response GetMySprintList(int MemberId)
        {
            _response = new Response();
            try
            {
                ISprintMemberAssociationBusiness SprintMemberService = new SprintMemberAssociationBusiness();
                _response.responseData = SprintMemberService.GetMySprintList(MemberId);
                _response.message = "Record loaded successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                SprintMemberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to add new Sprint Member Association
        /// </summary>
        /// <returns>List of Sprint Member Association</returns>
        [HttpPost]
        [Route("API/SprintMemberAssociationAPI/AddSprintAssociation")]
        public Response AddNewSprintMemberAssociation(SprintMemberAssociationCustomModel objSprintMemberModel)
        {
            _response = new Response();
            try
            {
                ISprintMemberAssociationBusiness SprintMemberService = new SprintMemberAssociationBusiness();
                _response.responseData = SprintMemberService.AddNewSprintMemberAssociation(objSprintMemberModel);
                _response.message = "Record saved successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                SprintMemberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to update Sprint
        /// </summary>
        /// <returns>Update Sprint</returns>
        [HttpGet]
        [Route("API/SprintMemberAssociationAPI/UpdateSprintStatus/{SprintId}/{Status}")]
        public Response UpdateSprintStatus(int SprintId, string Status)
        {
            _response = new Response();
            try
            {
                ISprintMemberAssociationBusiness SprintMemberService = new SprintMemberAssociationBusiness();
                _response.responseData = SprintMemberService.UpdateSprintStatus(SprintId, Status);
                _response.message = "Record saved successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                SprintMemberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to delete Sprint
        /// </summary>
        /// <returns>Delete Sprint</returns>
        [HttpGet]
        [Route("API/SprintMemberAssociationAPI/DeleteSprintAssociation/{SprintId}")]
        public Response DeleteSprintAssociation(int SprintId)
        {
            _response = new Response();
            try
            {
                ISprintMemberAssociationBusiness SprintMemberService = new SprintMemberAssociationBusiness();
                _response.responseData = SprintMemberService.DeleteSprintAssociation(SprintId);
                _response.message = "Record deleted successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                SprintMemberService = null;
            }
            return _response;
        }

    }
}
