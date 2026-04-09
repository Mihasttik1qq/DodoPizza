using System;
using System.Collections.Generic;

namespace MauiApp7.Models;

public class Order
{
    public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8); // Короткий ID заказа
    public List<CartItem> Items { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }

    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string DeliveryAddress { get; set; }
}