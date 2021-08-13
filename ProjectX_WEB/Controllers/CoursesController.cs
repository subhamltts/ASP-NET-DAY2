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
    public class CoursesController : ApiController
    {
        CoursesBL blObj; //Refernence Creation
        //Actions
        [HttpGet]
        [ActionName("GetCourse")]
        public HttpResponseMessage FetchAllCourses()
        {
            try
            {
                blObj = new CoursesBL();
                List<CoursesDTO> lst = blObj.DisplayCourse();
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
                    response.Content = new StringContent("There is no Course @ this Moment");
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
        [ActionName("GetCourseName")]
        public HttpResponseMessage FetchParticipantName(string courseId)
        {
            try
            {
                blObj = new CoursesBL();
                List<CoursesDTO> lst = blObj.GetCourseNameByID(courseId);
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
                    response.Content = new StringContent("There is no Course @ this Moment");
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
        [ActionName("AddCourse")]
        public HttpResponseMessage AddNewCourse(CoursesDTO inCourseObj)
        {
            try
            {
                if (inCourseObj != null && inCourseObj.CourseID != null && inCourseObj.CourseTitle != null && inCourseObj.Duration != 0 && inCourseObj.Owner!=null &&inCourseObj.AssessmentMode!=null)
                {
                    blObj = new CoursesBL();
                    int returnVal = blObj.AddNewCourse(inCourseObj);
                    if (returnVal == 1)
                    {
                        var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        successResponse.Content = new StringContent("Course Added Successfully");
                        return successResponse;
                    }
                    else
                    {
                        var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        successResponse.Content = new StringContent("Course NOT Added");
                        return successResponse;
                    }
                }
                else
                {
                    var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                    successResponse.Content = new StringContent("Batch Details Missing!");
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
