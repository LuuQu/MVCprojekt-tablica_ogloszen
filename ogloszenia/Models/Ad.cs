using System.ComponentModel.DataAnnotations;

namespace ogloszenia.Models
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MaxLength(512)]
        [MinLength(1)]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(256)]
        public string OwnerId { get; set; }
    }
}
