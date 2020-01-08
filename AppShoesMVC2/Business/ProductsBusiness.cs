using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductsBusiness
    {
        private static ProductsD obj = new ProductsD();

        public static void AddProd(Products prod)
        {
            obj.AddProd(prod);
        }
        public static List<Products> ListarProducts()
        {
            return obj.ListarProducts();
        }

        public static Products GetProducts(int id)
        {
            return obj.GetProducts(id);
        }

        public static void Edit(Products prod)
        {
            obj.Edit(prod);
        }

        /*public static void Delete(int id)
        {
            obj.Delete(id);
        }*/

        public static void LogDelete(Products prod)
        {
            obj.LogDelete(prod);
        }
    }
}
