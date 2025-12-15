namespace TREASURY.UI.Models.Treasury
{
    public class InterestCalculationModel
    {
        public int ID { get; set; }
        public int LENDERUNITID { get; set; }
        public int BORROWERUNITID { get; set; }
        public decimal AMOUNT { get; set; }
        public string STARTDATE { get; set; }
        public string ENDDATE { get; set; }
        public int NOOFDAYS { get; set; }
        public decimal INTERESTRATE { get; set; }
        public decimal INTERESTAMT { get; set; }
        public string DETAILS { get; set; }

        public int CREATEDBY { get; set; }
        public int UNITID { get; set; }
        public string CREATEDDATE { get; set; }
    }


    public class InterestCalculationViewModel
    {
        public int ID { get; set; }
        public int HID { get; set; }
        public int LENDERUNITID { get; set; }
        public string LENDERUNIT { get; set; }
        public int BORROWERUNITID { get; set; }
        public string BORROWERUNIT { get; set; }
        public string VAMOUNT { get; set; }
        public decimal AMOUNT { get; set; }
        public string STARTDATE { get; set; }
        public string ENDDATE { get; set; }
        public int NOOFDAYS { get; set; }
        public decimal INTERESTRATE { get; set; }
        public decimal INTERESTAMT { get; set; }
        public string VINTERESTAMT { get; set; }
        public string DETAILS { get; set; }
        public string DOCSTATUSCODE { get; set; }
        public string STATUS { get; set; }
        public string CREATEDDATE { get; set; }
        public string UPDATEDDATE { get; set; }

        public int CREATEDBY { get; set; }
        public int UPDATEDBY { get; set; }
    }
}
