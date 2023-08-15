﻿
namespace sureApp.domain.Interfaces
{
    public interface IVehicle
    {
        public string TypeName { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public bool IsItInspected { get; set; }
        public Type GetTypeResult();
    }
}
