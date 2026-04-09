using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp7.Models;
using MauiApp7.Services;
using System.Collections.ObjectModel;

namespace MauiApp7.ViewModels;

[QueryProperty(nameof(SelectedPizza), "pizza")]
public partial class ConstructorViewModel : ObservableObject
{
    private readonly CartService _cartService;

    [ObservableProperty] private Pizza selectedPizza;
    [ObservableProperty] private int quantity = 1;
    [ObservableProperty] private string selectedSize = "Маленькая";

    public ObservableCollection<Ingredient> Ingredients { get; } = new()
    {
        new Ingredient { Name = "Сыр", Price = 50 },
        new Ingredient { Name = "Бекон", Price = 90 },
        new Ingredient { Name = "Грибы", Price = 40 },
        new Ingredient { Name = "Оливки", Price = 30 }
    };

    public ConstructorViewModel(CartService cartService)
    {
        _cartService = cartService;
    }

    // Свойство для отображения итоговой цены
    public decimal TotalPrice
    {
        get
        {
            if (SelectedPizza == null) return 0;
            decimal mult = SelectedSize switch
            {
                "Средняя" => 1.3m,
                "Большая" => 1.6m,
                _ => 1.0m
            };

            decimal ingredientsPrice = Ingredients.Where(i => i.IsSelected).Sum(i => i.Price);
            return ((SelectedPizza.BasePrice * mult) + ingredientsPrice) * Quantity;
        }
    }

    [RelayCommand]
    public void RefreshPrice() => OnPropertyChanged(nameof(TotalPrice));

    [RelayCommand]
    public async Task AddToCart()
    {
        _cartService.Items.Add(new CartItem
        {
            Pizza = SelectedPizza,
            Quantity = Quantity,
            SizeName = SelectedSize,
            SizeMultiplier = SelectedSize == "Маленькая" ? 1.0m : SelectedSize == "Средняя" ? 1.3m : 1.6m,
            Ingredients = Ingredients.Where(i => i.IsSelected).ToList()
        });
        await Shell.Current.GoToAsync("..");
    }

    partial void OnSelectedSizeChanged(string value) => RefreshPrice();
    partial void OnQuantityChanged(int value) => RefreshPrice();
    partial void OnSelectedPizzaChanged(Pizza value) => RefreshPrice();
}