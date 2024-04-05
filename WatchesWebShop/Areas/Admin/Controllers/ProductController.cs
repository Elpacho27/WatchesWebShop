using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;
using WatchesWebShop.DataAccess.Repository.IRepository;
using WatchesWebShop.Models.Models;
using WatchesWebShop.Models.ViewModels;

namespace WatchesWebShop.Areas.Admin.Controllers;

public class ProductController : Controller
{

    private IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }


    public IActionResult Index()
    {
        List<Product> productList = _unitOfWork.Product.GetAll().ToList();
        return View(productList);
    }

    public IActionResult Create()
    {
        return View();

    }

    
    public IActionResult Upsert(int? id)
    {
        IEnumerable<SelectListItem> categoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        });

        ViewBag.CategoryList=categoryList;

        ProductViewModel productViewModel = new ProductViewModel()
        {
            CategoryList = categoryList,
            Product = new Product()
        };

        if(id==null || id==0) 
        {
            return View(productViewModel);
        }
        else
        {
            productViewModel.Product=_unitOfWork.Product.Get(p=>p.Id==id);
            return View(productViewModel );
        }
        
    }

    [HttpPost]
    public IActionResult Upsert(ProductViewModel productViewModel,IFormFile file)
    {
        if(ModelState.IsValid)
        {
            string wwwRootPath=_webHostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\product");


                if (!string.IsNullOrEmpty(productViewModel.Product.ImageURL))
                {
                    var oldImagePath = Path.Combine(wwwRootPath, productViewModel.Product.ImageURL.Trim('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                productViewModel.Product.ImageURL = @"\images\product\" + fileName;
            }
            if(productViewModel.Product.Id==0)
            {
                _unitOfWork.Product.Add(productViewModel.Product);

            }
            else
            {
                _unitOfWork.Product.Update(productViewModel.Product);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index","Product");

        }
        else
        {
            productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

        }
        return View(productViewModel);

    }

    #region API Calls
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        return Json(new { data = productList });
    }
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var product = _unitOfWork.Product.Get(p => p.Id == id);
        if (product == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }
        else
        {
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageURL.Trim('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted successfully" });
        }
    }
    #endregion
}
