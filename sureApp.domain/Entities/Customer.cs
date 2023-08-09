using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Entities
{
    internal class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string HomeTown { get; set; }
        public string Address { get; set; }
    }
}
