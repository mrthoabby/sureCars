using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Entities.DTO
{
    internal class CoverageDTO
    {
        public string Name {  get; set; }
        public string MaximunCoverageValue { get; set; }
        public string ValidFrom { get; set; }
        public string ValidUntil { get; set; }
        public int[] Features { get; set; }
    }
}
