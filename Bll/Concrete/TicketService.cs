
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
    public class TicketService : ITicketService
    {
        ITicketDal _ticketDal;
        public TicketService(ITicketDal ticketDal)
        {
            _ticketDal= ticketDal;
        }
        public void Delete(Ticket entity)
        {
            _ticketDal.Remove(entity);
        }

        public void DeleteById(int entityID)
        {
            Ticket ticket = _ticketDal.Get(a => a.ID == entityID);
            Delete(ticket);
        }

        public Ticket Get(int entityID)
        {
            return _ticketDal.Get(a => a.ID == entityID);
        }

        public ICollection<Ticket> GetAll()
        {
            return _ticketDal.GetAll().ToList();
        }

        public void Insert(Ticket entity)
        {
            _ticketDal.Add(entity);
        }

        public void Update(Ticket entity)
        {
            _ticketDal.Update(entity);
        }
    }
}
