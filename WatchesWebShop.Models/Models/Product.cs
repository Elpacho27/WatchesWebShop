using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchesWebShop.Models.Models;

public class Product
{
    public int Id { get; set; } 
    public string Brand { get; set; }
    public string Series { get; set; }
    public string ModelNumber { get; set; }

    [Range(1D, 1000D)]
    public double Price { get; set; }

    public int CategoryID { get; set; }
    [ForeignKey("CategoryID")]
    [ValidateNever]
    public Category Category { get; set; }
    [ValidateNever]
    public string ImageURL { get; set; }


}
