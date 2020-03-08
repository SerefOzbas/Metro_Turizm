using Core.Dal.EntityFramework;
using Dal.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete.EntityFramework
{
    public class TicketRepository : EFRepositoryBase<Ticket, MetroTurizmContext>, ITicketDal
    {
    }
}
