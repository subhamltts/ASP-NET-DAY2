using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class BatchDAL
    {
        Batch BatObj;
        public int AddNewBatch(BatchDTO dtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB();
                Batch obj = new Batch();
                obj.BatchID = dtoObj.BatchID;
                obj.BatchName = dtoObj.BatchName;
                obj.BatchStrength = dtoObj.BatchStrength;
                XobjDB.Batches.Add(obj);
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
        public int UpdateBatchName(BatchDTO dtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB(); //connection to Db
                BatObj = XobjDB.Batches.SingleOrDefault(d => d.BatchName == dtoObj.BatchName);
                if (BatObj != null)
                {
                    BatObj.BatchID = dtoObj.BatchID;
                    BatObj.BatchName = dtoObj.BatchName;
                    BatObj.BatchStrength = dtoObj.BatchStrength;
                    XobjDB.SaveChanges();
                    status = 1;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }
        public int DeleteBatchName(string batchName)
        {
            int status = 0;
            try
            {

                ProjectX_DB XobjDB = new ProjectX_DB();



                BatObj = XobjDB.Batches.SingleOrDefault(d => d.BatchName == batchName);
                if (BatObj != null)
                {
                    XobjDB.Batches.Remove(BatObj);
                    XobjDB.SaveChanges();


                }
                else
                    throw new Exception();

            }

            catch (Exception)
            {
                Console.WriteLine("Deletion failed. Something Went Wrong");
            }
            return status;
        }
        public List<Batch> DisplayBatch()
        {
            try
            {
                var display = new ProjectX_DB();

                List<Batch> deptList = display.Batches.ToList();

                return deptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BatchDTO> GetBatchNameByID(string BatId)
        {
            try
            {
                List<BatchDTO> lstResult = new List<BatchDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Batches.
                    Where(x => x.BatchName == BatId).ToList();
                foreach (var item in rndPartList)
                {
                    lstResult.Add(new BatchDTO()
                    {
                        BatchID = item.BatchID,
                        BatchName = item.BatchName,
                        BatchStrength = item.BatchStrength
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
