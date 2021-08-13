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
    public class BatchController : ApiController
    {
        BatchBL blObj;
        [HttpGet]
        [ActionName("GetBatch")]
        public HttpResponseMessage FetchAllBatch()
        {
            try
            {
                blObj = new BatchBL();
                List<BatchDTO> lstBatch = blObj.DisplayBatch();
                if (lstBatch != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(lstBatch));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no Batch @ this Moment");
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
        [ActionName("AddBatch")]
        public HttpResponseMessage AddNewBatch(BatchDTO inBatchObj)
        {
            try
            {
                if(inBatchObj!=null && inBatchObj.BatchID!=null && inBatchObj.BatchName!=null && inBatchObj.BatchStrength != 0)
                {
                    blObj = new BatchBL();
                    int returnVal = blObj.AddNewBatch(inBatchObj);
                    if(returnVal == 1)
                    {
                        var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        successResponse.Content = new StringContent("Batch Added Successfully");
                        return successResponse;
                    }
                    else
                    {
                        var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        successResponse.Content = new StringContent("Batch NOT Added");
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
            catch(Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Something went Wrong Try after SomeTimes");
                return response;
                throw ex;
            }
        }
    }
}
