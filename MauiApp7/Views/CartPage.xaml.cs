using MauiApp7.ViewModels;

namespace MauiApp7.Views;

public partial class CartPage : ContentPage
{
    public CartPage(CartViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}