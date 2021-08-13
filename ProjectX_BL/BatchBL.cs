using ProjectX_DTO;
using ProjextX_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_BL
{
    public class BatchBL
    {
        BatchDAL DalObj = new BatchDAL();
        public int AddNewBatch(BatchDTO dtoObj)
        {
            try
            {
                int returnVal = DalObj.AddNewBatch(dtoObj);
                return returnVal;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateBatchInfo(BatchDTO dtonewObj)
        {
            int result = DalObj.UpdateBatchName(dtonewObj);
            return result;
        }

        public int deleteBatchInfo(string BName)
        {
            int result = DalObj.DeleteBatchName(BName);
            return result;
        }
        public List<BatchDTO> DisplayBatch()
        {
            try
            {
                List<BatchDTO> lstBatch = new List<BatchDTO>();

                foreach (var item in DalObj.DisplayBatch())
                {
                    BatchDTO dtoObj = new BatchDTO
                    {
                        BatchID = item.BatchID,
                        BatchName = item.BatchName,
                        BatchStrength = item.BatchStrength,

                    };
                    lstBatch.Add(dtoObj);
                }
                return lstBatch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BatchDTO> GetParticipantName(string BId)
        {
            var partList = DalObj.GetBatchNameByID(BId);
            return partList;
        }
        public int UpdateBatchInfo(string name)
        {
            throw new NotImplementedException();
        }
    }
}
