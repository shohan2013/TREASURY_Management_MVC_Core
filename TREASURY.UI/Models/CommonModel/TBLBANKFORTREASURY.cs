using System.ComponentModel.DataAnnotations;

namespace TREASURY.UI.Models.CommonModel
{
    public class TBLBANKFORTREASURY
    {
        [Key]
        public int BANKID { get; set; }
        public string BANKNAME { get; set; }
        public string CODE { get; set; }
    }
}
