namespace TREASURY.UI.Models.TreasuryReport
{
    public class TreasuryReportModel
    {
        public int ID { get; set; }
        public int LENDERUNITID { get; set; }
        public int BORROWERUNITID { get; set; }
        public string LENDERUNIT { get; set; }
        public string BORROWERUNIT { get; set; }
        public string STARTDATE { get; set; }
        public string ENDDATE { get; set; }
        public decimal AMOUNT { get; set; }
        public string VAMOUNT { get; set; }
        public decimal GRANDTOTAL { get; set; }
        public decimal INTERESTAMT { get; set; }
        public string VINTERESTAMT { get; set; }
        public decimal GRANDINTERESTAMT { get; set; }
    }
}
