using System.ComponentModel.DataAnnotations;

namespace ogloszenia.Models
{
    public class Offer
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string name { get; set; }
        [Required]
        [MaxLength(500)]
        [MinLength(1)]
        public string description { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        [MaxLength(256)]
        public string ownerId { get; set; }
    }
}
