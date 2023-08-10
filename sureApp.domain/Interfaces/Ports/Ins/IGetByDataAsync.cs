using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Interfaces.Ports.In
{
    public interface IGetByDataAsync<Entity,EntityData>
    {
        Task<Entity> GetByDataAsync(EntityData data);
    }
}
