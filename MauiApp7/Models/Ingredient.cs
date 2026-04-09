using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp7.Models;

public partial class Ingredient : ObservableObject
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    [ObservableProperty]
    private bool isSelected;
}