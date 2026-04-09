using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp7.Services;

namespace MauiApp7.ViewModels;

public partial class OrderViewModel : ObservableObject
{
    private readonly CartService _cartService;

    [ObservableProperty] private string name;
    [ObservableProperty] private string phone;
    [ObservableProperty] private string address;

    public decimal TotalSum => _cartService.Items.Sum(x => x.TotalPrice);

    public OrderViewModel(CartService cartService) => _cartService = cartService;

    [RelayCommand]
    public async Task ConfirmOrder()
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Address))
        {
            await Shell.Current.DisplayAlert("Ошибка", "Заполните данные доставки", "OK");
            return;
        }

        try
        {
            // 1. Сохраняем
            await _cartService.SaveOrderToHistoryAsync(Name, Phone, Address);

            // 2. Уведомляем
            await Shell.Current.DisplayAlert("Успех", "Заказ успешно оформлен!", "OK");

            // 3. Возвращаемся в корень (самый надежный способ)
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.Navigation.PopToRootAsync();
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось сохранить заказ: {ex.Message}", "OK");
        }
    }
}