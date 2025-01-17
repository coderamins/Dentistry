using Dentistry.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Infrastructure.Seeds
{
    public static class DefaultOrderStatus
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            var orderStatusList = new List<OrderStatus>
            {
                new OrderStatus{Id= 1,StatusDesc="در حال بررسی"},
                new OrderStatus{Id= 2,StatusDesc="در حال ساخت"},
                new OrderStatus{Id= 3,StatusDesc="اتمام کار"},
                new OrderStatus{Id= 4,StatusDesc="ابطال شده"},
            };

            orderStatusList = orderStatusList.Where(s => !dbContext.OrderStatus.Select(x => x.Id).Contains(s.Id)).ToList();
            if (orderStatusList.Count() > 0)
            {
                await dbContext.OrderStatus.AddRangeAsync(orderStatusList);

                await dbContext.SaveChangesAsync();
            }
        }

    }
}
