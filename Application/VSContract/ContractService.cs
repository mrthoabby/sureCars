using Domain.ContractEntity;

namespace Application.VSContract
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _repository;

        public ContractService(IContractRepository repository)
        {
            _repository = repository;
        }
        public async Task<Contract> CreateAsync(Contract entity)
        {

            return await _repository.CreateAsync(entity);
        }
    }
}
