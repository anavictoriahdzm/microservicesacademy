using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductsD
    {

        public void AddProd(Products prod)
        {
            using (var db = new DataProductsContext())
            {
                db.Products.Add(prod);
                db.SaveChanges();
            }
        }
        public List<Products> ListarProducts()
        {
            using (var db = new DataProductsContext())
            {
                //return db.Products.ToList();
                return db.Products.Where(p => p.IsEnabled == true).ToList();
            }
        }

        public Products GetProducts(int id)
        {
            using (var db = new DataProductsContext())
            {
                //return db.Products.Find(id);
                return db.Products.Where(d => d.Id == id).FirstOrDefault();
            }
        }

        public void Edit(Products prod)
        {
            using (var db = new DataProductsContext())
            {
                var p = db.Products.Find(prod.Id);
                p.IdType = prod.IdType;
                p.IdColor = prod.IdColor;
                p.IdBrand = prod.IdBrand;
                p.IdProvider = prod.IdProvider;
                p.IdCatalog = prod.IdCatalog;
                p.Title = prod.Title;
                p.Nombre = prod.Nombre;
                p.Description = prod.Description;
                p.Observations = prod.Observations;
                p.PriceDistributor = prod.PriceDistributor;
                p.PriceClient = prod.PriceClient;
                p.PriceMember = prod.PriceMember;
                p.IsEnabled = prod.IsEnabled;
                p.Keywords = prod.Keywords;
                p.DateUpdate = prod.DateUpdate;
                db.SaveChanges();
            }
        }

        /*public void Delete(int id)
        {
            using (var db = new DataProductsContext())
            {
                var p = db.Products.Find(id);
                db.Products.Remove(p);
                db.SaveChanges();
            }
        }*/

        public void LogDelete (Products prod)
        {
            using (var db = new DataProductsContext())
            {
                var p = db.Products.Find(prod.Id);
                p.IsEnabled = false;
                prod.IsEnabled = false;
                db.SaveChanges();
            }
        }
    }
}
