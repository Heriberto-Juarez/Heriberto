using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeribertoAPI.Models.Domain
{
    public class Walk
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }


        [ForeignKey("Difficulty")]
        public Guid DifficultyId { get; set; }

        [ForeignKey("Region")]
        public Guid RegionId { get; set; }

        public Difficulty Difficulty { get; set; }

        public Region Region { get; set; }

    }
}
