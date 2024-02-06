using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrtderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }


        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }

        public int Count { get; set; }
        public double Price { get; set; }
    }
}
