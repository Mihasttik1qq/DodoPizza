using System;
using Microsoft.Maui.Controls;

namespace MauiApp7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Ловим исключения, которые не пойманы в UI-потоке
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();

                var ex = e.ExceptionObject as Exception;
                Console.WriteLine($"Unhandled exception: {ex?.Message}");
            };

            // Ловим исключения из асинхронных задач
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();

                Console.WriteLine($"Unobserved task exception: {e.Exception.Message}");
                e.SetObserved();
            };
        }
    }
}