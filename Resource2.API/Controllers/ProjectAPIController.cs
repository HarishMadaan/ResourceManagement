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
    public class ProjectAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IProjectBusiness projectService;
        #endregion

        public ProjectAPIController()
        {

        }

        public ProjectAPIController(ProjectBusiness _projectService)
        {
            this.projectService = _projectService;
        }

        /// <summary>
        /// This method is used to fetch Application Members
        /// </summary>
        /// <returns>List of Application Members</returns>
        [HttpGet]
        [Route("API/ProjectAPI/GetProjectListing")]
        public Response GetProjectListing(ProjectCustomModel objProjectModel)
        {
            _response = new Response();
            try
            {
                IProjectBusiness projectService = new ProjectBusiness();
                _response.responseData = projectService.GetProjectListing(objProjectModel);
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
                projectService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to fetch Application Members
        /// </summary>
        /// <returns>List of Application Members</returns>
        [HttpPost]
        [Route("API/ProjectAPI/AddNewProject")]
        public Response AddNewProject(ProjectCustomModel objProjectModel)
        {
            _response = new Response();
            try
            {
                IProjectBusiness projectService = new ProjectBusiness();
                _response.responseData = projectService.AddNewProject(objProjectModel);
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
                projectService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to fetch Application Members
        /// </summary>
        /// <returns>List of Application Members</returns>
        [HttpGet]
        [Route("API/ProjectAPI/DeleteProject/{ProjectId}")]
        public Response DeleteProject(int ProjectId)
        {
            _response = new Response();
            try
            {
                IProjectBusiness projectService = new ProjectBusiness();
                _response.responseData = projectService.DeleteProject(ProjectId);
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
                projectService = null;
            }
            return _response;
        }

    }
}
