using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class GraderDAL
    {
        Grader GraObj;
        public int AddGrader(GraderDTO dtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB();
                Grader obj = new Grader();
                obj.BatchID = dtoObj.BatchID;
                obj.ParticipantID = dtoObj.ParticipantID;
                obj.CourseID = dtoObj.CourseID;
                obj.Marks_Obtained = dtoObj.Marks_Obtained;
                obj.Feedback = dtoObj.Feedback;
                XobjDB.Graders.Add(obj);
                status = XobjDB.SaveChanges();
                if (status == 1)
                {
                    return status;
                }
                else
                {
                    return -99;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Grader> DisplayGrader()
        {
            try
            {
                var display = new ProjectX_DB();

                List<Grader> deptList = display.Graders.ToList();

                return deptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GraderDTO> GetMarksByParticipant(int participantId)
        {
            try
            {
                List<GraderDTO> lstResult = new List<GraderDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Graders.
                    Where(x => x.ParticipantID == participantId).ToList();
                foreach (var item in rndPartList)
                {
                    lstResult.Add(new GraderDTO()
                    {
                        BatchID = item.BatchID,
                        ParticipantID = item.ParticipantID,
                        CourseID = item.CourseID,
                        Marks_Obtained = item.Marks_Obtained,
                        Feedback = item.Feedback
                    });
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GraderDTO> GetMarksByCourse(string courseId)
        {
            try
            {
                List<GraderDTO> lstResult = new List<GraderDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Graders.
                    Where(x => x.CourseID == courseId).ToList();
                foreach (var item in rndPartList)
                {
                    lstResult.Add(new GraderDTO()
                    {
                        BatchID = item.BatchID,
                        ParticipantID = item.ParticipantID,
                        CourseID = item.CourseID,
                        Marks_Obtained = item.Marks_Obtained,
                        Feedback = item.Feedback
                    });
                }
                return lstResult;
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
                List<GraderDTO> lstResult = new List<GraderDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Graders.
                    Where(x => x.BatchID == batchId).ToList();
                foreach (var item in rndPartList)
                {
                    lstResult.Add(new GraderDTO()
                    {
                        BatchID = item.BatchID,
                        ParticipantID = item.ParticipantID,
                        CourseID = item.CourseID,
                        Marks_Obtained = item.Marks_Obtained,
                        Feedback = item.Feedback
                    });
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
