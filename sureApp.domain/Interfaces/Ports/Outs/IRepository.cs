using sureApp.domain.Interfaces.Ports.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Interfaces.Ports.Out
{
    public interface IRepository<Entity,EntityId,EntityData>
        :ICreateAsync<Entity>,
        IGetByDataAsync<Entity, EntityData>,
        IGetByIdAsync<Entity, EntityId>,
        IGetAllAsync<Entity>
    {
    }
}
