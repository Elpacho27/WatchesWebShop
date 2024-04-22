using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WatchesWebShop.DataAccess.Repository.IRepository;
using WatchesWebShop.Models;
using WatchesWebShop.Models.Models;



namespace WatchesWebShop.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(string type = null)
    {
        IEnumerable<Product> productList;

        if (type == null || type == "All")
        {
            productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        }
        else
        {
            productList = _unitOfWork.Product.GetProductsByType(type).ToList();
        }

        ViewBag.Brands = _unitOfWork.Product.GetAll().Select(p => p.Brand).Distinct();

        return View(productList);
    }
    /*public IActionResult Index()
    {
        IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        return View(productList);
    }*/


    public IActionResult Details(int? productId)
    {
        Product product = _unitOfWork.Product.Get(p => p.Id == productId, includeProperties: "Category");
        return View(product);
    }

    public IActionResult ShowProducts(string type)
    {
        var products = _unitOfWork.Product.GetProductsByType(type);
        return View("Index", products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    
}
