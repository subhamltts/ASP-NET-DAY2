using ProjectX_DTO;
using ProjextX_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_BL
{
    public class ParticipantsBL
    {
        ProjextX_DAL.ParticipantsDAL DalObj = new ProjextX_DAL.ParticipantsDAL();

        public int AddNewParticipant(ParticipantDTO dtoObj)
        {
            try
            {
                int returnVal = DalObj.AddNewParticipant(dtoObj);
                return returnVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ParticipantDTO> DisplayParticipant()
        {
            try
            {
                List<ParticipantDTO> lstParticipant = new List<ParticipantDTO>();

                foreach (var item in DalObj.DisplayParticipant())
                {
                    ParticipantDTO dtoObj = new ParticipantDTO
                    {
                        ParticipantID = item.ParticipantID,
                        ParticipantName = item.ParticipantName,
                        ParticipantEmailID = item.ParticipantEmailID,
                        
                    };
                    lstParticipant.Add(dtoObj);
                }
                return lstParticipant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<ParticipantDTO> GetParticipantName(int participantId)
        {
            try
            {
                var partList = DalObj.GetParticipantNameByID(participantId);
                return partList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
