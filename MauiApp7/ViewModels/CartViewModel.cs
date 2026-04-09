using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp7.Models;
using MauiApp7.Services;
using MauiApp7.Views;
using System.Collections.ObjectModel;

namespace MauiApp7.ViewModels;

public partial class CartViewModel : ObservableObject
{
    private readonly CartService _cartService;
    public ObservableCollection<CartItem> CartItems => _cartService.Items;
    public decimal TotalAmount => CartItems.Sum(x => x.TotalPrice);

    public CartViewModel(CartService cartService) => _cartService = cartService;

    [RelayCommand]
    public void RemoveItem(CartItem item)
    {
        _cartService.RemoveItem(item);
        OnPropertyChanged(nameof(TotalAmount));
    }

    [RelayCommand]
    public async Task GoToOrder()
    {
        if (CartItems.Count > 0)
            await Shell.Current.GoToAsync(nameof(OrderPage));
    }
}