using sureApp.domain.Entities;
using sureApp.domain.Interfaces.Ports.In;
using sureApp.domain.Interfaces.Ports.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.Application.Services
{
    internal class InsurancePolicyService : ICreateAsync<InsurancePolicy>,
        IGetByIdAsync<InsurancePolicy,Guid>,
        IGetByDataAsync<InsurancePolicy,string>,
        IGetAllAsync<InsurancePolicy>
    {
        private readonly IRepository<InsurancePolicy,Guid,string> _repository;

        public InsurancePolicyService(IRepository<InsurancePolicy, Guid,string> repository)
        {
            _repository = repository;
        }

        public async Task<InsurancePolicy> CreateAsync(InsurancePolicy entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<IQueryable<InsurancePolicy>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<InsurancePolicy> GetByDataAsync(string data)
        {
            return await _repository.GetByDataAsync(data);
        }

        public async Task<InsurancePolicy> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
