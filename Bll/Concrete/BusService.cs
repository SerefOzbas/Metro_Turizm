using Bll.Abstract;
using Dal.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Concrete
{
    public class BusService : IBusService
    {
        IBusDal _busDal;
        public BusService(IBusDal busDal)
        {
            _busDal = busDal;
        }
        public void Delete(Bus entity)
        {
            _busDal.Remove(entity);
        }

        public void DeleteById(int entityID)
        {
            Bus bus = _busDal.Get(a => a.ID == entityID);
            Delete(bus);
        }

        public Bus Get(int entityID)
        {
            return _busDal.Get(a => a.ID == entityID);
        }

        public ICollection<Bus> GetAll()
        {
            return _busDal.GetAll().ToList();
        }

        public List<Bus> GetBusController(string busdate, string departurecity, string returncity)
        {
            return _busDal.GetAll(a => a.BusDate == busdate && a.DepartureCity == departurecity && a.ReturnCity == returncity).ToList();
        }

        public void Insert(Bus entity)
        {
            _busDal.Add(entity);
        }

        public void Update(Bus entity)
        {
            _busDal.Update(entity);
        }
    }
}
