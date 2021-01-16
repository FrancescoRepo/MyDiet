using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Models
{
    public class MealProduct
    {
        public int MealId { get; set; }

        public Meal Meal { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
