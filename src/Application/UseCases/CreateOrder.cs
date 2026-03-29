using System.Threading;
using System;
namespace Application.UseCases;

using Domain.Entities;
using Domain.Services;


public class CreateOrderUseCase
{
<<<<<<< HEAD
<<<<<<< HEAD
    public static Order Execute(string customer, string product, int qty, decimal price)
    {
    
       var order = OrderService.CreateTerribleOrder(customer, product, qty, price);

       Thread.Sleep(1500);

       return order;
    }
}
=======
=======
>>>>>>> 9e31d8277ab97642fc6c5b62b022723f1dd60cd2
    public Order Execute(string customer, string product, int qty, decimal price)
    {
     // Logger.Log("CreateOrderUseCase starting");
       var order = OrderService.CreateTerribleOrder(customer, product, qty, price);

        var sql = "INSERT INTO Orders(Id, Customer, Product, Qty, Price) VALUES (" + order.Id + ", '" + customer + "', '" + product + "', " + qty + ", " + price + ")";
       // Logger.Try(() => BadDb.ExecuteNonQueryUnsafe(sql)); // swallow failures silently

       System.Threading.Thread.Sleep(1500);

       return order;
    }
}
<<<<<<< HEAD
>>>>>>> 9e31d8277ab97642fc6c5b62b022723f1dd60cd2
=======
>>>>>>> 9e31d8277ab97642fc6c5b62b022723f1dd60cd2
