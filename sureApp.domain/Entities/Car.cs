using sureApp.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Entities
{
    internal class Car : IVehicle
    {
        [Required]
        public string Plate { get ; set ; }
        [Required]
        public string Model { get ; set ; }
        [Required]
        public bool IsItInspected { get ; set ; }
        Type IVehicle.GetType() => typeof(Car);
    }
}
