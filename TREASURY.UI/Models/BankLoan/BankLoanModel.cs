namespace TREASURY.UI.Models.BankLoan
{
    public class BankLoanModel
    {
        public int ID { get; set; }
        public int LENDERBANKID { get; set; }
        public int BORROWERUNITID { get; set; }
        public int LOANTYPEID { get; set; }
        public decimal LOANAMOUNT { get; set; }
        public int CURRENCYID { get; set; }
        public decimal CONRATE { get; set; }

        public string ISSUEDATE { get; set; }
        public string MATURITYDATE { get; set; }
        public decimal INTERESTRATE { get; set; }

        public string LOANNUMBER { get; set; }
        public string NARRATION { get; set; }
        public int CREATEDBY { get; set; }
        public string CREATEDDATE { get; set; }
        public int UNITID { get; set; }
    }

    public class BankLoanViewModel
    {
        public int ID { get; set; }
        public int LENDERBANKID { get; set; }
        public string LENDERBANK { get; set; }
        public int BORROWERUNITID { get; set; }
        public string BORROWERUNIT { get; set; }
        public int LOANTYPEID { get; set; }
        public string LOANTYPE { get; set; }

        public decimal LOANAMOUNT { get; set; }
        public int CURRENCYID { get; set; }
        public string CURRENCY { get; set; }

        public decimal CONRATE { get; set; }

        public string ISSUEDATE { get; set; }
        public string MATURITYDATE { get; set; }
        public decimal INTERESTRATE { get; set; }

        public string LOANNUMBER { get; set; }
        public string NARRATION { get; set; }
    }
}
