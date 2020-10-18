using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (Model1 db = new Model1())
            {
                return db.Products.ToList();
            }
        }
        [HttpGet]
        public IEnumerable<Product> Get(int id)
        {
            using (Model1 db = new Model1())
            {
                yield return db.Products.FirstOrDefault(p => p.ID == id);
            }
        }
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            using (Model1 db = new Model1())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var prod = db.Products.FirstOrDefault(p => p.ID == id);
                if(prod != null)
                {
                    db.Products.Remove(prod);
                    db.SaveChanges();
                }
            }
        }
        [HttpPut]
        public void Put(int id,[FromBody] Product prod)
        {
            using (Model1 db = new Model1())
            {
                var product = db.Products.FirstOrDefault(p => p.ID == id);
                if(product!= null)
                {
                    product.Name = prod.Name;
                    product.Price = prod.Price;
                    db.SaveChanges();
                }
            }
        }
    }
}
