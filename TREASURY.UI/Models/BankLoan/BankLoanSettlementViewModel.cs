namespace TREASURY.UI.Models.BankLoan
{
    public class BankLoanSettlementViewModel
    {
        public int ID { get; set; }
        public int LENDERBANKID { get; set; }
        public string LENDERBANK { get; set; }
        public int BORROWERUNITID { get; set; }
        public string BORROWERUNIT { get; set; }
        //public int LOANTYPEID { get; set; }
        //public string LOANTYPE { get; set; }


        public decimal AMOUNT { get; set; }
        public decimal PAYMENT { get; set; }
        public string PRNO { get; set; }


        public string PAYMENTDATE { get; set; }

        public string RESCHEDULEDPAYMENTDATE { get; set; }

        public int TYPEID { get; set; }
        public string TYPE { get; set; }
        public string REFLOANNUMBER { get; set; }

        public string LOANTYPE { get; set; }
        public int CURRENCYID { get; set; }
        public string CURRENCY { get; set; }


        public decimal CRATE { get; set; }

        public int REFID { get; set; }
        public string NARRATION { get; set; }
    }


    public class BankLoanSettlementModel
    {
        public int ID { get; set; }
        public decimal PAYMENT { get; set; }
        public string PAYMENTDATE { get; set; }

        public string RESCHEDULEDPAYMENTDATE { get; set; }
        public string REFLOANNUMBER { get; set; }
        public decimal CRATE { get; set; }
        public int REFID { get; set; }
        public string NARRATION { get; set; }
        public int CREATEDBY { get; set; }
    }
}
