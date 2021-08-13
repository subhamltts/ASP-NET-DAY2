using ProjectX_DTO;
using ProjextX_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_BL
{
    public class FacultyBL
    {
        FacultyDAL DalObj = new FacultyDAL();

        public int AddNewFaculty(FacultyDTO dtoObj)
        {
            try
            {
                int returnVal = DalObj.AddNewFaculty(dtoObj);
                return returnVal;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<FacultyDTO> DisplayFaculty()
        {
            try
            {
                List<FacultyDTO> lstFaculty = new List<FacultyDTO>();

                foreach (var item in DalObj.DisplayFaculty())
                {
                    FacultyDTO dtoObj = new FacultyDTO
                    {
                        PSNo = item.PSNo,
                        FacultyName = item.FacultyName,
                        EmailID = item.EmailID,

                    };
                    lstFaculty.Add(dtoObj);
                }
                return lstFaculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FacultyDTO> GetFacultyName(int fId)
        {
            try
            {
                var partList = DalObj.GetFacultyNameByID(fId);
                return partList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
