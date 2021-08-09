using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using FirstWebApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiServer.Models;

namespace WebApiServer.Services
{
    public class ProductServices :MongoDbService<Product>
    {

        public Product Get(string id) =>
            _collection.Find<Product>(order => order.Id.ToString() == id).FirstOrDefault();

        public void Update(string id, Product orderIn) =>
            _collection.ReplaceOne(order => order.Id.ToString() == id, orderIn);

        public void Remove(Product orderIn) =>
            _collection.DeleteOne(order => order.Id == orderIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(order => order.Id.ToString() == id);

        public ProductServices(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}