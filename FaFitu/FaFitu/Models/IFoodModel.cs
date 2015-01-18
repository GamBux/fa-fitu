using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaFitu.Models
{
    public interface IFoodModel : IDbModel
    {
        [Required]
        [Display(Name = "Name of food")]
        string Name { get; set; }
        string Description { get; set; }

        NutrientsModel Nutrients { get; set; }
    }
}
