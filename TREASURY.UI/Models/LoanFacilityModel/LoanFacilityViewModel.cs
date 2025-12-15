namespace TREASURY.UI.Models.LoanFacilityModel
{
    public class LoanFacilityModel
    {
        public int ID { get; set; }
        public int UNITID { get; set; }
        public string SANCTIONREF { get; set; }
        public decimal SODLIMIT { get; set; }
        public string EXPIREDATE { get; set; }
        public int INNERUNITID { get; set; }
        public int BANKID { get; set; }
        public decimal RAWMATERIALLIMIT { get; set; }
        public decimal LOANLIMIT { get; set; }
        public decimal MACHINERYLIMIT { get; set; }
        public decimal SHORTTERMLOAN { get; set; }
        public decimal OVERDRAFTFACILITY { get; set; }
        public decimal BANKGUARANTEELIMIT { get; set; }
        public decimal TIMELOANLIMIT { get; set; }
        public decimal TERMLOANLIMIT { get; set; }

        public decimal LCSPARESMACHINERYLIMIT { get; set; }
        public decimal TOTAL { get; set; }
        public int CREATEDBY { get; set; }
    }

    public class LoanFacilityViewModel
    {
        public int ID { get; set; }
        public string SANCTIONNO { get; set; }
        public string SANCTIONREF { get; set; }
        public decimal SODLIMIT { get; set; }
        public string EXPIREDATE { get; set; }
        public int UNITID { get; set; }
        public string UNIT { get; set; }
        public int INNERUNITID { get; set; }
        public string INNERUNIT { get; set; }
        public int BANKID { get; set; }
        public string BANKNAME { get; set; }
        public decimal RAWMATERIALLIMIT { get; set; }
        public decimal LOANLIMIT { get; set; }
        public decimal MACHINERYLIMIT { get; set; }
        public decimal SHORTTERMLOAN { get; set; }
        public decimal OVERDRAFTFACILITY { get; set; }
        public decimal BANKGUARANTEELIMIT { get; set; }
        public decimal TIMELOANLIMIT { get; set; }
        public decimal TERMLOANLIMIT { get; set; }

        public decimal LCSPARESMACHINERYLIMIT { get; set; }
        public decimal TOTAL { get; set; }
    }
}
