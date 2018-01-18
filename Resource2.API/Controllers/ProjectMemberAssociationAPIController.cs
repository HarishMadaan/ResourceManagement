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
    public class ProjectMemberAssociationAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IProjectMemberAssociationBusiness projectMemberService;
        #endregion

        public ProjectMemberAssociationAPIController()
        {

        }

        public ProjectMemberAssociationAPIController(ProjectMemberAssociationBusiness _projectMemberService)
        {
            this.projectMemberService = _projectMemberService;
        }

        /// <summary>
        /// This method is used to fetch Project list
        /// </summary>
        /// <returns>List of Projects</returns>
        [HttpGet]
        [Route("API/ProjectMemberAssociationAPI/GetMyProjectList/{MemberId}")]
        public Response GetMyProjectList(int MemberId)
        {
            _response = new Response();
            try
            {
                IProjectMemberAssociationBusiness projectMemberService = new ProjectMemberAssociationBusiness();
                _response.responseData = projectMemberService.GetMyProjectList(MemberId);
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
                projectMemberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to add new Project Member Association
        /// </summary>
        /// <returns>List of Project Member Association</returns>
        [HttpPost]
        [Route("API/ProjectMemberAssociationAPI/AddNewAssociation")]
        public Response AddNewAssociation(ProjectMemberAssociationCustomModel objProjectMemberModel)
        {
            _response = new Response();
            try
            {
                IProjectMemberAssociationBusiness projectMemberService = new ProjectMemberAssociationBusiness();
                _response.responseData = projectMemberService.AddNewProjectMemberAssociation(objProjectMemberModel);
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
                projectMemberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to delete Project Member Association
        /// </summary>
        /// <returns>Delete Project Member Association</returns>
        [HttpGet]
        [Route("API/ProjectMemberAssociationAPI/DeleteProjectAssociation/{ProjectId}")]
        public Response DeleteProjectAssociation(int ProjectId)
        {
            _response = new Response();
            try
            {
                IProjectMemberAssociationBusiness projectMemberService = new ProjectMemberAssociationBusiness();
                _response.responseData = projectMemberService.DeleteProjectAssociation(ProjectId);
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
                projectMemberService = null;
            }
            return _response;
        }


    }
}
