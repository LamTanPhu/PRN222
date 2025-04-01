using System.ComponentModel.DataAnnotations;

namespace ModelViews.Entity
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
       
     
        public Guid FKProfileId { get; set; }
        public ChildrenProfile Profile { get; set; }
        public int TotalAmount { get; set; }
        public int TotalOrderPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Status { get; set; }
    }
}
