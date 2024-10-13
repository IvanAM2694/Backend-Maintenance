using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    [Index(nameof(Email), IsUnique = true, Name = "IX_EMAIL")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid Guid { get; set; }

        [MaxLength(125)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string LastName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Gender { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ChangedAt { get; set; }
    }
}
