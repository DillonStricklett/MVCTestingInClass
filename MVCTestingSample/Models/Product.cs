using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestingSample.Models
{
    public class Product
    {
        private string name;

        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name
        {
            get => name;
            set =>  // If value is null throw \/
                name = value ?? throw new ArgumentNullException($"{nameof(Name)} cannot be null");
        }

        public string Price { get; set; }
    }
}
