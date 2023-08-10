using sureApp.domain.Entities;
using sureApp.domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Ports.In
{
    internal interface ICreatePolicy
    {
        public InsurancePolicy CreateWithNewCustomer(CarDTO car,CoverageDTO coverage,CustomerDTO customer );
    }
}
