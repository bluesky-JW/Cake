using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cakeshop.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int CakeId { get; set; }
        [ForeignKey("CakeId")]
        public virtual Cake? Cake { get; set; }

        [Range(1, 100, ErrorMessage = "數量必須介於1和100之間")]
        [Display(Name ="數量")]
        public int Quantity { get; set; }

        //連結到使用者(哪個使用者的購物車)
        public string? UserId { get; set; } //外鍵到ApplicationUser{Id是string類型}
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
