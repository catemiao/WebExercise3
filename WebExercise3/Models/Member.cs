using System;
using System.ComponentModel.DataAnnotations;

namespace WebExercise3.Models
{
    public class Member
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        [Required]
        [StringLength(10)]
        public string? Phone { get; set; }

        [Required]
        [StringLength(10)]
        public string? Tel { get; set; }

        [Required]
        [StringLength(1)]
        public string? Gender { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
