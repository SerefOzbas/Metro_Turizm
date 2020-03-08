using Dal.Abstract;
using Dal.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Ninject
{
    public class CustomDalModel : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserDal>().To<UserRepository>();
            Bind<IBusDal>().To<BusRepository>();
            Bind<ITicketDal>().To<TicketRepository>();
        }
    }
}