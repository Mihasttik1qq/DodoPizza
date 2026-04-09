using MauiApp7.Services;
using MauiApp7.ViewModels;
using MauiApp7.Views;

namespace MauiApp7;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

        builder.Services.AddSingleton<CartService>();

        builder.Services.AddTransient<MenuViewModel>();
        builder.Services.AddTransient<ConstructorViewModel>();
        builder.Services.AddTransient<CartViewModel>();
        builder.Services.AddTransient<OrderViewModel>();

        builder.Services.AddTransient<MenuPage>();
        builder.Services.AddTransient<ConstructorPage>();
        builder.Services.AddTransient<CartPage>();
        builder.Services.AddTransient<OrderPage>();

        return builder.Build();
    }
}