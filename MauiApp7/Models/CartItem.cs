namespace MauiApp7.Models;

public class CartItem
{
    public Pizza Pizza { get; set; }
    public string SizeName { get; set; }
    public decimal SizeMultiplier { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new();
    public int Quantity { get; set; }

    public decimal TotalPrice => ((Pizza.BasePrice * SizeMultiplier) +
                                   Ingredients.Sum(i => i.Price)) * Quantity;

    public string Description => $"{SizeName}, {(Ingredients.Any() ? string.Join(", ", Ingredients.Select(i => i.Name)) : "без добавок")}";
}