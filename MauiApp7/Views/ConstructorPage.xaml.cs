namespace MauiApp7.Views;

public partial class ConstructorPage : ContentPage
{
    // VS автоматически прокинет ConstructorViewModel сюда
    public ConstructorPage(ViewModels.ConstructorViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}