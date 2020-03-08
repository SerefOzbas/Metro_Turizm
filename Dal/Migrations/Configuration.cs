namespace Dal.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dal.MetroTurizmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Dal.MetroTurizmContext context)
        {
            DateTime timezero = Convert.ToDateTime("00:00");
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 24; j += 6)
                {
                    context.Buses.Add(new Bus() { BusDate = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"), BusTime = timezero.AddHours(j).ToString("HH:mm"), DepartureCity = "İstanbul", ReturnCity = "İzmir", NumberofPeople = 0, Price = 30, IsitFull = false });
                    context.Buses.Add(new Bus() { BusDate = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"), BusTime = timezero.AddHours(j).ToString("HH:mm"), DepartureCity = "İstanbul", ReturnCity = "Ankara", NumberofPeople = 0, Price = 50, IsitFull = false });
                    context.Buses.Add(new Bus() { BusDate = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"), BusTime = timezero.AddHours(j).ToString("HH:mm"), DepartureCity = "İzmir", ReturnCity = "Ankara", NumberofPeople = 0, Price = 20, IsitFull = false });
                }
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
