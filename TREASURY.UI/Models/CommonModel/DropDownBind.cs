using System.ComponentModel.DataAnnotations.Schema;

namespace TREASURY.UI.Models.CommonModel
{
    public class DropDownBind
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class DropDownBindDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DETAILS { get; set; }
    }
}
