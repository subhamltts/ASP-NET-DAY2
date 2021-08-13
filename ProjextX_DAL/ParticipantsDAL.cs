using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class ParticipantsDAL
    {
        Participant PartObj;
        public int AddNewParticipant(ParticipantDTO dtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB();
                Participant obj = new Participant();
                obj.ParticipantID = dtoObj.ParticipantID;
                obj.ParticipantName = dtoObj.ParticipantName;
                obj.ParticipantEmailID = dtoObj.ParticipantEmailID;
                XobjDB.Participants.Add(obj);
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<Participant> DisplayParticipant()
        {
            try
            {
                var display = new ProjectX_DB();

                List<Participant> deptList = display.Participants.ToList();

                return deptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ParticipantDTO> GetParticipantNameByID(int partId)
        {
            try
            {
                List<ParticipantDTO> lstResult = new List<ParticipantDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Participants.
                    Where(x => x.ParticipantID == partId).ToList();
                foreach(var item in rndPartList)
                {
                    lstResult.Add(new ParticipantDTO()
                    {
                        ParticipantID = item.ParticipantID,
                        ParticipantName = item.ParticipantName,
                        ParticipantEmailID = item.ParticipantEmailID
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
