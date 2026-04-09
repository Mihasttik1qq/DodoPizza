using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp7.Models;
using System.Collections.ObjectModel;

namespace MauiApp7.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    public ObservableCollection<Pizza> Pizzas { get; set; } = new()
    {
        new Pizza { Id=1, Name="Маргарита", Description="Томаты, моцарелла", BasePrice=350, ImageUrl="pizza1.png" },
        new Pizza { Id=2, Name="Пепперони", Description="Острые колбаски", BasePrice=450, ImageUrl="pizza2.png" },
        new Pizza { Id=3, Name="4 Сыра", Description="Много разного сыра", BasePrice=550, ImageUrl="pizza3.png" }
    };

    [RelayCommand]
    async Task SelectPizza(Pizza pizza) =>
        await Shell.Current.GoToAsync("ConstructorPage", new Dictionary<string, object> { ["pizza"] = pizza });

    [RelayCommand]
    async Task GoToCart() => await Shell.Current.GoToAsync("CartPage");
}