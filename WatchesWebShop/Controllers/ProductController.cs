﻿using Microsoft.AspNetCore.Mvc;
using WatchesWebShop.DataAccess.Repository.IRepository;
using WatchesWebShop.Models.Models;

namespace WatchesWebShop.Controllers;

public class ProductController : Controller
{

    private IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public IActionResult Index()
    {
        List<Product> productList=_unitOfWork.Product.GetAll().ToList();
        return View(productList);
    }

    public IActionResult Create()
    {
        return View();

    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if(ModelState.IsValid)
        {
            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
            return RedirectToAction("Index","Product");
        }
        return View();
    }

    public IActionResult Edit(int? productId)
    {
        if(productId == null || productId==0)
        {
            return NotFound();
        }

        Product? product=_unitOfWork.Product.Get(c=>c.Id==productId);
        if(product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Product");

        }
        return View();


    }

    public IActionResult Delete(int? productId)
    {
        if(productId==null || productId==0)
        {
            return NotFound();
        }
        Product? product=_unitOfWork.Product.Get(c=>c.Id==productId);

        if(product == null)
        {
            return NotFound();
        }
        return View(product);

    }
    [HttpPost,ActionName("Delete")]
    public IActionResult DeletePROD(int? productId)
    {
        Product? product=_unitOfWork.Product.Get(c=>c.Id == productId);
        if(product == null)
        {
            return NotFound();
        }
        _unitOfWork.Product.Delete(product);
        _unitOfWork.Save();
        return RedirectToAction("Index", "Product");

    }
}
