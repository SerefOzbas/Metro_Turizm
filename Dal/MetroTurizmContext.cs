using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
   public class MetroTurizmContext:DbContext
    {
        public MetroTurizmContext() : base(@"Server=.;Database=MetroTurizmDb;Integrated Security=true;")
        {
            Database.SetInitializer(new BusInitializer());
        }
        public DbSet<User> User { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(a => a.PropertyType == typeof(DateTime)).Configure(a => a.HasColumnType("datetime2"));
        }

        class BusInitializer : CreateDatabaseIfNotExists<MetroTurizmContext>
        {
            protected override void Seed(MetroTurizmContext context)
            {

                DateTime timezero = Convert.ToDateTime("00:00");
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 24; j+=6)
                    {
                        context.Buses.Add(new Bus() { BusDate = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"), BusTime = timezero.AddHours(j).ToString("HH:mm"),DepartureCity="İstanbul",ReturnCity="İzmir",NumberofPeople = 0,Price=30,IsitFull = false });
                        context.Buses.Add(new Bus() { BusDate = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"), BusTime = timezero.AddHours(j).ToString("HH:mm"), DepartureCity = "İstanbul", ReturnCity = "Ankara", NumberofPeople = 0,Price=50,IsitFull = false });
                        context.Buses.Add(new Bus() { BusDate = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"), BusTime = timezero.AddHours(j).ToString("HH:mm"), DepartureCity = "İzmir", ReturnCity = "Ankara", NumberofPeople = 0, Price = 20, IsitFull = false });
                    }
                }
                context.SaveChanges();
                base.Seed(context);

            }
        }

    }

}
