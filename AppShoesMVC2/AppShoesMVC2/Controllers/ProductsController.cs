using Entity;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppShoesMVC2.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var datosProducts = ProductsBusiness.ListarProducts();
            return View(datosProducts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products prod)
        {
            try
            {
                ProductsBusiness.AddProd(prod);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(prod);
            }
            
        }

        public ActionResult GetProduct(int id)
        {
            var prod = ProductsBusiness.GetProducts(id);
            return View(prod);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var prod = ProductsBusiness.GetProducts(id);
            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(Products prod)
        {
            try
            {
                ProductsBusiness.Edit(prod);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(prod);
            }
        }
        /*public ActionResult Delete(int? id)
        {
            var prod = ProductsBusiness.GetProducts(id.Value);
            return View(prod);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ProductsBusiness.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }*/

        public ActionResult LogDelete(int id)
        {
            var prod = ProductsBusiness.GetProducts(id);
            return View(prod);
        }

        [HttpPost]
        public ActionResult LogDelete(Products prod)
        {
            try
            {
                ProductsBusiness.LogDelete(prod);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(prod);
            }
        }
    }
}