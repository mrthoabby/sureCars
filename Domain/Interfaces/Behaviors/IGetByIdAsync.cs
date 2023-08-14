using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Interfaces.Behaviors
{
    internal interface IGetByIdAsync<Entity, EntityIdentifier> where Entity : class
    {
        Task<Entity> GetByIdAsync(EntityIdentifier id);
    }
}
