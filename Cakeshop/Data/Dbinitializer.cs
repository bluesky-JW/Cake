using Cakeshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cakeshop.Data
{
    public class Dbinitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // 檢查資料庫是否存在，如果不存在則建立
            context.Database.EnsureCreated();

            //檢查是否已有蛋糕資料
            if (context.Cakes.Any())
            {
                return; // DB has been seeded
            }

            var cakes = new Cake[]
            {
                new Cake{Name="水果巧克力蛋糕", Description="酸甜好滋味",Price=550.00m, ImageUrl="/images/1.jpeg"},
                new Cake{Name="經典巧克力蛋糕", Description="巧克力搭餅乾加上奶油",Price=650.00m, ImageUrl="/images/2.jpeg"},
                new Cake{Name="紅蘿蔔蛋糕", Description="健康紅蘿蔔好吃無法擋",Price=500.00m, ImageUrl="/images/3.jpeg"},
                new Cake{Name="焦糖蛋糕", Description="焦糖上放巧克力混合出好滋味",Price=580.00m, ImageUrl="/images/4.jpeg"},
                new Cake{Name="草莓蛋糕", Description="草莓蛋糕",Price=550.00m, ImageUrl="/images/5.jpeg"},
            };

            foreach (Cake c in cakes)
            {
                context.Cakes.Add(c);
            }
            context.SaveChanges(); // 儲存蛋糕資料

            //可以加入初始資料

        }


    }
}
