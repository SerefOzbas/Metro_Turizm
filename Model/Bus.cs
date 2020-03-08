using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Bus: BaseEntity
    {
        public string BusDate { get; set; }
        public string BusTime { get; set; }
        public int NumberofPeople { get; set; }
        public string DepartureCity { get; set; }
        public string ReturnCity { get; set; }
        public bool IsitFull { get; set; }
        public int Price { get; set; }
    }
}
