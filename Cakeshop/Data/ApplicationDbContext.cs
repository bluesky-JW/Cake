﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cakeshop.Models;

namespace Cakeshop.Data;

public class ApplicationDbContext : IdentityDbContext
{
    //修改這裡，使用你擴充的 ApplicationUser
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    //加入你的 DbSet
    public DbSet<Cake> Cakes { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); //必須先呼叫基底類的 OnModelCreating
        //設定 Decimal 精確度(如果沒有用 Data Annotation 的話)
        builder.Entity<Cake>()
               .Property(c => c.Price)
               .HasColumnType("decimal(18, 2)");

        builder.Entity<Order>()
               .Property(o => o.TotalAmount)
               .HasColumnType("decimal(18,2)");

        builder.Entity<OrderDetail>()
               .Property(od => od.Price)
               .HasColumnType("decimal(18,2)");

    }
}
