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
    public class ModelController : ApiController
    {
        ModelBL blObj;
        [HttpGet]
        [ActionName("GetModel")]
        public HttpResponseMessage FetchAllModel()
        {
            try
            {
                blObj = new ModelBL();
                List<ModelDTO> lst = blObj.DisplayModel();
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
                    response.Content = new StringContent("There is no Model @ this Moment");
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
        [ActionName("AddModel")]
        public HttpResponseMessage AddNewModel(ModelDTO inModelObj)
        {
            try
            {
                if (inModelObj != null && inModelObj.ModelID != 0 && inModelObj.ModelName != null && inModelObj.ModelOwner != null)
                {
                    blObj = new ModelBL();
                    int returnVal = blObj.AddNewModel(inModelObj);
                    if (returnVal == 1)
                    {
                        var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        successResponse.Content = new StringContent("Model Added Successfully");
                        return successResponse;
                    }
                    else
                    {
                        var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        successResponse.Content = new StringContent("Model NOT Added");
                        return successResponse;
                    }
                }
                else
                {
                    var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                    successResponse.Content = new StringContent("Model Details Missing!");
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
