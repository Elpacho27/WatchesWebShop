using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchesWebShop.Models.Models;

public class Product
{
    public int Id { get; set; } 
    public string Title { get; set; }

    public string Description { get; set; }

    public string ISBN { get; set; }

    public string Author { get; set; }
    [DisplayName("List price")]
    [Range(1D, 1000D)]
    public double ListPrice { get; set; }
    [Range(1D, 1000D)]
    public double Price { get; set; }
    [Range(1D, 1000D)]
    public double Price50 { get; set; }
    [DisplayName("Price for 100+")]
    [Range(1D, 1000D)]
    public double Price100 { get; set;}

}
