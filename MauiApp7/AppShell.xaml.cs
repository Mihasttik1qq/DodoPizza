using MauiApp7.Views;

namespace MauiApp7;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ConstructorPage), typeof(ConstructorPage));
        Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
        Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
    }
}