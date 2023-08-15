using sureApp.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.ValueObjects
{
    public sealed record Car : IVehicle
    {
        public Car(string plate,string model,bool isItInspected) {
            Plate = plate;
            Model = model;
            IsItInspected = isItInspected;
            TypeName = typeof(Car).Name;
        }

        public string Plate { get;  set; }
        public string Model { get;  set; }
        public bool IsItInspected { get; set ; }
        public string TypeName { get; set; }
        Type IVehicle.GetTypeResult() => GetType();
    }
}
