using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.domain.Interfaces.Ports.In
{
    public interface IGetAllAsync<Entity>
    {
        Task<IQueryable<Entity>>GetAllAsync();
    }
}
