using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Models.ViewModels
{
    public class CreateEditPatientViewModel
    {
        public Patient Patient { get; set; }
        public decimal Weight { get; set; }
    }
}
