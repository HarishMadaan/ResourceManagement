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
    public class SprintAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private ISprintBusiness SprintService;
        #endregion

        public SprintAPIController()
        {

        }

        public SprintAPIController(SprintBusiness _SprintService)
        {
            this.SprintService = _SprintService;
        }

        /// <summary>
        /// This method is used to fetch Application Members
        /// </summary>
        /// <returns>List of Application Members</returns>
        [HttpGet]
        [Route("API/SprintAPI/GetProjectSprintListing/{ProjectId}")]
        public Response GetProjectSprintListing(int ProjectId)
        {
            _response = new Response();
            try
            {
                ISprintBusiness SprintService = new SprintBusiness();
                _response.responseData = SprintService.GetProjectSprintListing(ProjectId);
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
                SprintService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to fetch Application Members
        /// </summary>
        /// <returns>List of Application Members</returns>
        [HttpPost]
        [Route("API/SprintAPI/AddNewSprint")]
        public Response AddNewSprint(SprintCustomModel model)
        {
            _response = new Response();
            try
            {
                ISprintBusiness SprintService = new SprintBusiness();
                _response.responseData = SprintService.AddNewSprint(model);
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
                SprintService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to fetch Application Members
        /// </summary>
        /// <returns>List of Application Members</returns>
        [HttpGet]
        [Route("API/SprintAPI/DeleteSprint/{SprintId}")]
        public Response DeleteSprint(int SprintId)
        {
            _response = new Response();
            try
            {
                ISprintBusiness SprintService = new SprintBusiness();
                _response.responseData = SprintService.DeleteSprint(SprintId);
                _response.message = "Records deleted successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                SprintService = null;
            }
            return _response;
        }

    }
}
