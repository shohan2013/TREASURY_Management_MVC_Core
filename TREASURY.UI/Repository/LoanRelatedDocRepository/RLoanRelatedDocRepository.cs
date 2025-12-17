using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Reactive;
using TREASURY.UI.Models.LoanRelatedDoc;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.LoanRelatedDocService;

namespace TREASURY.UI.Repository.TreasuryRepository.LoanRelatedDocRepository
{
    public class RLoanRelatedDocRepository : ILoanRelatedDoc
    {
        private DBSecurityDbContext _context;
        private ICommon _common;
        string strMsg = "";
        string strStatusMsg = "";

        public RLoanRelatedDocRepository(DBSecurityDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }


        public async Task<Tuple<string, string>> Delete(int id, int createdby)
        {
            await _context.TBLLOANRELATEDDOC.Where(x => x.Id == id).ExecuteUpdateAsync(a => a.SetProperty(x => x.Isactive, false)
                                                                                              .SetProperty(x => x.CreatedBy, createdby)
            );

            //var obj =await _context.TBLLOANRELATEDDOC.FirstOrDefaultAsync(x => x.Id == id);

            return Tuple.Create("Record Updated Successfully.", "success");


            //if(obj != null)
            //{
            //    obj.Isactive = false;
            //    await _context.SaveChangesAsync();
            //    return Tuple.Create("success", "Data Updated Successfully.");
            //}
            //return Tuple.Create("error", "Unable to Update Successfully.");
            //var ID = new TBLLOANRELATEDDOC { Id=id};
            //_context.Remove(ID);
            //await _context.SaveChangesAsync();
            //return Tuple.Create("success","Data Saved Successfully.");


        }

        public async Task<List<LoanRelatedDocView>> GetData(int bankid, int unitid)
        {
            try
            {
                return await (
                from loanrelateddoc in _context.TBLLOANRELATEDDOC
                join bank in _context.TBLBANKFORTREASURY on loanrelateddoc.BankId equals bank.BANKID
                join unit in _context.TBLUNITFORTREASURY on loanrelateddoc.UnitId equals unit.ID
                where ((loanrelateddoc.BankId == 0 || loanrelateddoc.BankId == bankid) && loanrelateddoc.Isactive == true)
                select new LoanRelatedDocView
                {
                    Id = loanrelateddoc.Id,
                    Code = loanrelateddoc.Code,
                    TotalFacility = loanrelateddoc.TotalFacility,
                    DetailsOfMortgageLand = loanrelateddoc.DetailsOfMortgageLand,
                    NoOfAcre = loanrelateddoc.NoOfAcre,
                    FreeLandQuantity = loanrelateddoc.FreeLandQuantity,

                    BankId = bank.BANKID,
                    BankName = bank.BANKNAME,
                    UnitId = unit.ID,
                    UnitName = unit.Name
                }
                     ).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        public async Task<IEnumerable<LoanRelatedDocView>> GetDataByID(int id)
        {
            try
            {
                return await (
                from loanrelateddoc in _context.TBLLOANRELATEDDOC
                join bank in _context.TBLBANKFORTREASURY on loanrelateddoc.BankId equals bank.BANKID
                join unit in _context.TBLUNITFORTREASURY on loanrelateddoc.UnitId equals unit.ID
                where (loanrelateddoc.Id == id)
                select new LoanRelatedDocView
                {
                    Id = loanrelateddoc.Id,
                    Code = loanrelateddoc.Code,
                    TotalFacility = loanrelateddoc.TotalFacility,
                    DetailsOfMortgageLand = loanrelateddoc.DetailsOfMortgageLand,
                    NoOfAcre = loanrelateddoc.NoOfAcre,
                    FreeLandQuantity = loanrelateddoc.FreeLandQuantity,

                    BankId = bank.BANKID,
                    BankName = bank.BANKNAME,
                    UnitId = unit.ID,
                    UnitName = unit.Name
                }
                     ).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Tuple<string, string>> Save(TBLLOANRELATEDDOC master)
        {
            //if(model != null)
            //    return Tuple.Create("error", "Model is null");

            //_context.LoanRelatedDoc.Add(model);
            //await _context.SaveChangesAsync();
            //return Tuple.Create("success", "Saved Successfully");

            try
            {
                SqlParameter BankId = new SqlParameter("@BANKID", master.BankId);
                SqlParameter UnitId = new SqlParameter("@UNITID", master.UnitId);
                SqlParameter TotalFacility = new SqlParameter("@TOTALFACILITY", master.TotalFacility);
                SqlParameter DetailsOfMortgageLand = new SqlParameter("@DETAILSOFMORTGAGELAND", master.DetailsOfMortgageLand);
                SqlParameter NoOfAcre = new SqlParameter("@NOOFACRE", master.NoOfAcre);
                SqlParameter NoOfAcrePerLegalRecord = new SqlParameter("@NOOFACREPERLEGALRECORD", master.NoOfAcrePerLegalRecord);
                SqlParameter FreeLandQuantity = new SqlParameter("@FREELANDQUANTITY", master.FreeLandQuantity);
                SqlParameter CreatedBy = new SqlParameter("@CreatedBy", master.CreatedBy);


                var MSG = new SqlParameter
                {
                    ParameterName = "@MSG",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                var STATUSMSG = new SqlParameter
                {
                    ParameterName = "@STATUSMSG",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                await _context.Database.ExecuteSqlRawAsync("Exec SPINSERTLOANRELATEDDOC @BANKID, @UNITID, @TOTALFACILITY, @DETAILSOFMORTGAGELAND, @NOOFACRE, @NOOFACREPERLEGALRECORD, @FREELANDQUANTITY,@CreatedBy,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    BankId, UnitId, TotalFacility, DetailsOfMortgageLand, NoOfAcre, NoOfAcrePerLegalRecord, FreeLandQuantity, CreatedBy, MSG, STATUSMSG);



                strMsg = MSG.Value.ToString();
                strStatusMsg = STATUSMSG.Value.ToString();
                return Tuple.Create(strMsg, strStatusMsg);
            }
            catch (Exception ex)
            {
                // _common.ErrorLog("", ex.ToString(), enumIMPSubMenu.SQ00001.ToString(), enumIMPProcessName.SQ.ToString(), 0, master.CREATEDBY, "");
            }
            return null;
        }

        public async Task<Tuple<string, string>> Update(TBLLOANRELATEDDOC model)
        {
            try
            {
                var obj = await _context.TBLLOANRELATEDDOC.FirstOrDefaultAsync(x => x.Id == model.Id);

                if (obj == null)
                {
                    return Tuple.Create("error", "Record Not Found.");
                }
                else
                {
                    obj.BankId = model.BankId;
                    obj.UnitId = model.UnitId;
                    obj.TotalFacility = model.TotalFacility;
                    obj.DetailsOfMortgageLand = model.DetailsOfMortgageLand;
                    obj.NoOfAcre = model.NoOfAcre;
                    obj.NoOfAcrePerLegalRecord = model.NoOfAcrePerLegalRecord;
                    obj.FreeLandQuantity = model.FreeLandQuantity;


                    // Optional audit fields
                    obj.UpdatedBy = model.UpdatedBy;
                    obj.UpdatedDate = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    return Tuple.Create("Record Updated Successfully.", "success");
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
