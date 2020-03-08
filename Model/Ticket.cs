using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Ticket: BaseEntity
    {
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsItPaid { get; set; }

    }
}
