using System.Collections.ObjectModel;
using System.Text.Json;
using MauiApp7.Models;

namespace MauiApp7.Services;

public class CartService
{
    public ObservableCollection<CartItem> Items { get; set; } = new();
    private string _filePath = @"C:\Users\студент\NET maui guides\MauiApp7\MauiApp7\json\orders_history.json";

    public void RemoveItem(CartItem item)
    {
        if (item != null && Items.Contains(item))
            Items.Remove(item);
    }

    public async Task SaveOrderToHistoryAsync(string name, string phone, string address)
    {
        var newOrder = new Order
        {
            Items = Items.ToList(),
            TotalAmount = Items.Sum(x => x.TotalPrice),
            OrderDate = DateTime.Now,
            CustomerName = name,
            CustomerPhone = phone,
            DeliveryAddress = address
        };

        List<Order> history = new();
        if (File.Exists(_filePath))
        {
            try
            {
                string json = await File.ReadAllTextAsync(_filePath);
                history = JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
            }
            catch { }
        }

        history.Add(newOrder);
        await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(history));
        Items.Clear();
    }
}