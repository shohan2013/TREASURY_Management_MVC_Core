namespace TREASURY.UI.Models.LoanRelatedDoc
{
    public class TBLLOANRELATEDDOC
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int BankId { get; set; }
        public int UnitId { get; set; }

        public decimal TotalFacility { get; set; }
        public string DetailsOfMortgageLand { get; set; }
        public decimal NoOfAcre { get; set; }

        public decimal NoOfAcrePerLegalRecord { get; set; }
        public decimal FreeLandQuantity { get; set; }
        public bool Isactive { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
