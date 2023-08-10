using sureApp.domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sureApp.domain.Entities
{
    public class Coverage:IValidator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double MaximunCoverageValue { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        [Required]
        public DateTime ValidUntil { get; set; }
        public virtual ICollection<CoverageFeature> Features { get; set; }
        public bool IsValid() => ValidUntil >= ValidUntil;
    }
}
