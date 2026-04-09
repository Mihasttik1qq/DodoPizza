using MauiApp7.Models;

namespace MauiApp7.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.MenuViewModel();
    }

    private async void OnSelectClicked(object sender, EventArgs e)
    {
        if (sender is not Button button) return;
        if (button.BindingContext is not Pizza pizza) return;

        // Используем зарегистрированный маршрут
        await Shell.Current.GoToAsync($"{nameof(ConstructorPage)}?pizzaId={pizza.Id}");
    }

    private async void OnCartClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("cart");
    }
}