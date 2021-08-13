using ProjectX_DTO;
using ProjextX_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_BL
{
    public class GraderBL
    {
        GraderDAL dalObj = new GraderDAL();
        public int GraderInputValues(GraderDTO dtoObj)
        {
            try
            {
                int returnVal = dalObj.AddGrader(dtoObj);
                return returnVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GraderDTO> DisplayGrader()
        {
            try
            {
                List<GraderDTO> lstGrader = new List<GraderDTO>();
                foreach(var item in dalObj.DisplayGrader())
                {
                    GraderDTO dtoObj = new GraderDTO
                    {
                        Marks_Obtained = item.Marks_Obtained,
                        Feedback = item.Feedback,
                        BatchID = item.BatchID,
                        ParticipantID = item.ParticipantID,
                        CourseID = item.CourseID
                    };
                    lstGrader.Add(dtoObj);
                }
                return lstGrader;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<GraderDTO> GetMarksByParticipant(int participantId)
        {
            try
            {
                var graderList = dalObj.GetMarksByParticipant(participantId);
                return graderList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<GraderDTO> GetMarksByCourse(string courseId)
        {
            try
            {
                var graderList = dalObj.GetMarksByCourse(courseId);
                return graderList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GraderDTO> GetMarksByBatch(string batchId)
        {
            try
            {
                var graderList = dalObj.GetMarksByBatch(batchId);
                return graderList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
