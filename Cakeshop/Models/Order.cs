﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cakeshop.Models
{
    public enum OrderStatus
    {
        [Display(Name ="處理中")]
        Pending,
        [Display(Name = "已確認")]
        Confirmed,
        Shipped,
        [Display(Name ="已完成")]
        Completed,
        [Display(Name = "已取消")]
        Cancelled
    }
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty; //外鍵到ApplicationUser
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Required]
        [Display(Name ="訂購日期")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,2")]
        [Display(Name ="訂單總額")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "收貨地址")]
        public string Shipping { get; set; } = string.Empty; //下單時的地址快照

        [Required]
        [StringLength(50)]
        [Display(Name = "收貨人姓名")]
        public string RecipientName { get; set; } = string.Empty; //下單時的姓名快照

        [Required]
        [StringLength(20)]
        [Display(Name = "聯絡電話")]
        public string RecipientPhone { get; set; } = string.Empty; //下單時的電話快照

        [Required]
        [Display(Name = "訂單狀態")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        // 導覽屬性 (一筆訂單包含多個訂單項目)
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
