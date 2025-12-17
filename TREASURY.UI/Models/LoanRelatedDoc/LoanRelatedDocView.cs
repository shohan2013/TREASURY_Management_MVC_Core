namespace TREASURY.UI.Models.LoanRelatedDoc
{

    public class LoanRelatedDocView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public decimal TotalFacility { get; set; }
        public string DetailsOfMortgageLand { get; set; }
        public decimal NoOfAcre { get; set; }

        public decimal NoOfAcrePerLegalRecord { get; set; }
        public decimal FreeLandQuantity { get; set; }


    }
}
