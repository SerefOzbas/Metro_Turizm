﻿using Core.Dal.EntityFramework;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Abstract
{
    public interface ITicketDal : IRepository<Ticket>
    {
    }
}
