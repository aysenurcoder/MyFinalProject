using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,sql server, Postgre, MongoDb
            _products = new List<Product> {
                new Product{PruductId=1,CategoryId=1,PoductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{PruductId=2,CategoryId=1,PoductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{PruductId=3,CategoryId=2,PoductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{PruductId=4,CategoryId=2,PoductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{PruductId=5,CategoryId=2,PoductName="Fare",UnitPrice=85,UnitsInStock=1}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda
            Product productToDelete = _products.SingleOrDefault(p=>p.PruductId == product.PruductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.PruductId == product.PruductId);
            productToUpdate.PoductName = product.PoductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
