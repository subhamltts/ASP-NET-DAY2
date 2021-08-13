using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class ModelDAL
    {
        public int AddNewModel(ModelDTO dtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB();
                Model obj = new Model();
                obj.ModelID = dtoObj.ModelID;
                obj.ModelName = dtoObj.ModelName;
                obj.ModelOwner = dtoObj.ModelOwner;
                obj.ModelDate = dtoObj.ModelDate;
                XobjDB.Models.Add(obj);
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
        public List<Model> DisplayModel()
        {
            try
            {
                var display = new ProjectX_DB();
                List<Model> lstModel = display.Models.ToList();
                return lstModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
