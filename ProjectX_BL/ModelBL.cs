using ProjectX_DTO;
using ProjextX_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_BL
{
    public class ModelBL
    {
        ModelDAL dalObj = new ModelDAL();
        public int AddNewModel(ModelDTO dtoObj)
        {
            try
            {
                int returnVal = dalObj.AddNewModel(dtoObj);
                return returnVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ModelDTO> DisplayModel()
        {
            try
            {
                List<ModelDTO> lstModel = new List<ModelDTO>();
                foreach(var item in dalObj.DisplayModel())
                {
                    ModelDTO modelDTOObj = new ModelDTO
                    {
                        ModelID = item.ModelID,
                        ModelName = item.ModelName,
                        ModelOwner = item.ModelOwner,
                        ModelDate = item.ModelDate
                    };
                    lstModel.Add(modelDTOObj);
                }
                return lstModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
