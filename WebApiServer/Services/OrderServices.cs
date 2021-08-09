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
    public class OrderServices : MongoDbService<Order>
    {

        public Order Get(string id) =>
            _collection.Find<Order>(order => order.Id.ToString() == id).FirstOrDefault();

        public void Update(string id, Order orderIn) =>
            _collection.ReplaceOne(order => order.Id.ToString() == id, orderIn);

        public void Remove(Order orderIn) =>
            _collection.DeleteOne(order => order.Id == orderIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(order => order.Id.ToString() == id);

        public OrderServices(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}