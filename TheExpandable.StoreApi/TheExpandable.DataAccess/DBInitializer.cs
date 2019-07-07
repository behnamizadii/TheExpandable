using System.Linq;
using TheExpandable.Entities;

namespace TheExpandable.DataAccess
{
    public static class DBInitializer
    {
        public static void Seed(StoreDataContext context)
        {
            if (!context.Items.Any())
            {
                context.AddRange(
                    new Item(){ItemId = "12AD23", Name = "Apple Pencil", Price = 120},
                    new Item(){ItemId = "12AB33", Name = "Apple Airpod", Price = 160},
                    new Item(){ItemId = "12AD26", Name = "Beats Solo 2", Price = 240},
                    new Item(){ItemId = "12AD75", Name = "JBL Bluetooth", Price = 90},
                    new Item(){ItemId = "12AJ89", Name = "Jabra Earphone", Price = 70},
                    new Item(){ItemId = "12AQ12", Name = "Fitbit Alta", Price = 80},
                    new Item(){ItemId = "12ADB53", Name = "Xiaomi Drone", Price = 245}
                );
                context.SaveChanges();
            }
        }
    }
}