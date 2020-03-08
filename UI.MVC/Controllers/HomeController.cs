using Bll.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UI.MVC.Tools;

namespace UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IBusService _busService;
        ITicketService _ticketService;
        IUserService _userService;
        public HomeController(IBusService busService,ITicketService ticketService,IUserService userService)
        {
            _busService = busService;
            _ticketService = ticketService;
            _userService = userService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            DateTime now = DateTime.Now;        
            List<string> datebus20 = new List<string>();           
            for (int i = 0; i < 20; i++)
            {
               datebus20.Add(now.AddDays(i).ToString(("dd/MM/yyyy")));
            }                      
            List<string> city = new List<string>();
            city.Add("Ankara");
            city.Add("İstanbul");
            city.Add("İzmir");

            SelectList list = new SelectList(datebus20, "datebus");          
            SelectList list3 = new SelectList(city,"city");
            ViewBag.busdate = list;        
            ViewBag.buscity = list3;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Bus bus)
        {
            List<Bus> buscontroller = _busService.GetBusController(bus.BusDate,bus.DepartureCity,bus.ReturnCity);
            RouteValueDictionary list = new RouteValueDictionary();
            for (int i = 0; i < buscontroller.Count; i++)
            {
                list["buscontroller[" + i.ToString()+"]"] = buscontroller[i];
            }
            if (buscontroller.Count != 0)
            {
                    return RedirectToAction("BuyTicket", "Home",new {busdate=bus.BusDate,departurecity=bus.DepartureCity,returncity=bus.ReturnCity } );                         
            }
            return RedirectToAction("Hata", "Home");
        }
        [HttpGet]
        public ActionResult Hata()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BuyTicket(string busdate,string departurecity,string returncity)
        {
            List<Bus> buscontroller = _busService.GetBusController(busdate, departurecity, returncity);
            return View(buscontroller.ToList());
        }
        public ActionResult Pay(int Id)
        {
            Bus bus = _busService.Get(Id);
            bus.NumberofPeople = bus.NumberofPeople + 1;
            _busService.Update(bus);
            Ticket ticket = new Ticket();
            ticket.UserId =(int) Session["UserID"];
            ticket.BusId = Id;
            ticket.IsItPaid = true;
            _ticketService.Insert(ticket);                  
           MailHelper.SendTicketMail((_userService.Get((int)Session["UserID"])).FirstName, (_userService.Get((int)Session["UserID"])).Email,bus);          
            return RedirectToAction("ListTickets","Home");
                     
        }

        public ActionResult ListTickets()
        {
            ViewBag.Bus = _busService.GetAll();
            return View(_ticketService.GetAll());
        }
    }
}