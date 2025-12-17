using System.ComponentModel.DataAnnotations;

namespace TREASURY.UI.Models.CommonModel
{
    public class TBLUNITFORTREASURY
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
