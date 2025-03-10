using System.ComponentModel.DataAnnotations;

namespace ModelViews.Entity
{
    public class OrderVaccineDetail
    {
        [Key]
        public Guid OrderVaccineDetailId { get; set; }
        public Guid FKOrderId { get; set; }
        public Order Order { get; set; }
        public int FKVaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
