using sureApp.domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Entities
{
    internal class InsurancePolicy
    {
        public Guid IdentifierNumber { get; set; }
        public DateTime CreateAt { get; set; }
        public EnumPolicyCoverage Coverage { get; set; }
        public double MaximunCoverageValue{
            get{ 
                return Coverage switch
                {
                    EnumPolicyCoverage.Liability => 1000000,
                    EnumPolicyCoverage.Collision => 3000000,
                    EnumPolicyCoverage.Comprehensive => 5000000,
                    EnumPolicyCoverage.MedicalPayments => 7000000,
                    EnumPolicyCoverage.UninsuredMotorist => 9000000,
                    EnumPolicyCoverage.PersonalInjuryProtection => 15000000,
                    _ => 0, 
                };
            }
        }
        public string Name
        {
            get
            {
                return Enum.GetName(typeof(EnumPolicyCoverage), this.Coverage)!;
            }
        }
    }
}
