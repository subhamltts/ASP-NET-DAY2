using Newtonsoft.Json;
using ProjectX_BL;
using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectX_WEB.Controllers
{
    public class FacultyController : ApiController
    {
        FacultyBL blObj; //Refernence Creation
        //Actions
        [HttpGet]
        [ActionName("GetFaculty")]
        public HttpResponseMessage FetchAllFaculty()
        {
            try
            {
                blObj = new FacultyBL();
                List<FacultyDTO> lst = blObj.DisplayFaculty();
                if (lst != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no faculty @ this Moment");
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Something went Wrong Try after SomeTimes");
                return response;
                throw ex;
            }
        }

        [HttpGet]
        [ActionName("GetFacultyName")]
        public HttpResponseMessage FetchFacultyName(int facultyId)
        {
            try
            {
                blObj = new FacultyBL();
                List<FacultyDTO> lst = blObj.GetFacultyName(facultyId);
                if (lst != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no Faculty @ this Moment");
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Something went Wrong Try after SomeTimes");
                return response;
                throw ex;
            }
        }

        [HttpPost]
        [ActionName("AddFaculty")]
        public HttpResponseMessage AddNewFaculty(FacultyDTO inFacultyObj)
        {
            try
            {
                if (inFacultyObj != null && inFacultyObj.PSNo != 0 && inFacultyObj.FacultyName != null && inFacultyObj.EmailID != null)
                {
                    blObj = new FacultyBL();
                    int returnVal = blObj.AddNewFaculty(inFacultyObj);
                    if (returnVal == 1)
                    {
                        var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        successResponse.Content = new StringContent("Faculty Added Successfully");
                        return successResponse;
                    }
                    else
                    {
                        var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        successResponse.Content = new StringContent("Faculty NOT Added");
                        return successResponse;
                    }
                }
                else
                {
                    var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                    successResponse.Content = new StringContent("Faculty Details Missing!");
                    return successResponse;
                }
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Something went Wrong Try after SomeTimes");
                return response;
                throw ex;
            }
        }
    }
}
