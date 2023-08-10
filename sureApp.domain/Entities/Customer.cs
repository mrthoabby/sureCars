﻿namespace sureApp.domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string HomeTown { get; set; }
        public string Address { get; set; }
        public int IdentificationNumber { get; set; }
    }
}
