using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Abstract
{
    public interface IBusService : IBaseService<Bus>
    {
        List<Bus> GetBusController(string busdate,string departurecity,string returncity);
    }
}
