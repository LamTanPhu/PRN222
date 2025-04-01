using System.ComponentModel.DataAnnotations;

namespace ModelViews.Entity
{
    public class VaccineBatch
    {
        [Key]
        public int VaccineBatchId { get; set; }
 
        public int FKCenterId { get; set; }
        public VaccineCenter Center { get; set; }
        public int Quantity { get; set; }
        public string ActiveStatus { get; set; }
    }

}
