using Microsoft.AspNetCore.Mvc;
using WatchesWebShop.DataAccess.Repository.IRepository;
using WatchesWebShop.Models.Models;

namespace WatchesWebShop.Areas.Admin.Controllers;

public class CategoryController : Controller
{

    private IUnitOfWork _unitOfWork;
    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }



    public IActionResult Index()
    {
        List<Category> categorylist = _unitOfWork.Category.GetAll().ToList();
        return View(categorylist);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category.Name.Length > 15)
        {
            ModelState.AddModelError("Name", "Longer than 15 characters");
        }
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Category");
        }

        return View();

    }

    public IActionResult Edit(int? categoryId)
    {
        if (categoryId == null || categoryId == 1)
        {
            return NotFound();

        }

        Category? category = _unitOfWork.Category.Get(c => c.Id == categoryId);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);

    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Category");
        }

        return View();
    }

    public IActionResult Delete(int? categoryId)
    {
        if (categoryId == null || categoryId == 0)
        {
            return NotFound();

        }
        Category? category = _unitOfWork.Category.Get(c => c.Id == categoryId);

        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? categoryId)
    {
        Category? category = _unitOfWork.Category.Get(c => c.Id == categoryId);
        if (category == null)
        {
            return NotFound();

        }

        _unitOfWork.Category.Delete(category);
        _unitOfWork.Save();
        return RedirectToAction("Index", "Category");

    }


}
