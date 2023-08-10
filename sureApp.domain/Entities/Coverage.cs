using sureApp.domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sureApp.domain.Entities
{
    public class Coverage:IValidator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MaximunCoverageValue { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsValid() => ValidUntil > ValidFrom;
    }
}
