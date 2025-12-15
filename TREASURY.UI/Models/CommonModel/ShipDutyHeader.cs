using System.ComponentModel.DataAnnotations;

namespace TREASURY.UI.Models.CommonModel
{
    public class ShipDutyHeader
    {
        [Key]
        public int ID { get; set; }
        public string SUPPLIERNAME { get; set; }
        public string SHIPMENTSEQUENCE { get; set; }
        public string UNITNAME { get; set; }
        public string CUSTOMHOUSENAME { get; set; }
    }
}
