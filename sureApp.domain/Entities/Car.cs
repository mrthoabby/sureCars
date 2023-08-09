using sureApp.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Entities
{
    internal class Car : IVehicle
    {
        public string Plate { get ; set ; }
        public string Model { get ; set ; }
        public bool IsItInspected { get ; set ; }
    }
}
