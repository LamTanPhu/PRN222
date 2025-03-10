using System.ComponentModel.DataAnnotations;

namespace ModelViews.Entity
{
    public class Feedback
    {
        [Key]
        public Guid FeedbackId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
