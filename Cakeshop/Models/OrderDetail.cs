﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cakeshop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; } //外鍵到Order
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }

        public int CakeId { get; set; } //外鍵到Cake
        [ForeignKey("CakeId")]
        public virtual Cake? Cake { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "數量")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        [Display(Name = "單價(當時)")]
        public decimal Price { get; set; } //下單當時的蛋糕價格快照
    }
}
