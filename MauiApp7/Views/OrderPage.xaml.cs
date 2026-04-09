namespace MauiApp7.Views;

public partial class OrderPage : ContentPage
{
    public OrderPage(ViewModels.OrderViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}