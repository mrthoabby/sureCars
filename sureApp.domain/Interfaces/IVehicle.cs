using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Interfaces
{
    internal interface IVehicle
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public bool IsItInspected { get; set; }
    }
}
