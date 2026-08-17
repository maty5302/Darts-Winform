using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DataLayer;
using DesktopUI.ViewModels;
using DesktopUI.Views;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI;

public partial class App : Application
{
    public static IServiceProvider? Services { get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // 1. Inicializace Dependency Injection
        var services = new ServiceCollection();

        // Zaregistrování repozitáře jako Singleton (sdílená instance pro celou aplikaci)
        services.AddSingleton<IDartsRepository, DartsRepository>();

        // Zaregistrování ViewModelů
        services.AddTransient<MainViewModel>();
        services.AddTransient<StatisticsViewModel>();
        // services.AddTransient<DuelViewModel>(); // Sem pak můžeš přidat další

        Services = services.BuildServiceProvider();

        // 2. "Zahřátí" databáze na pozadí pro eliminaci studeného startu (Cold Start)
        Task.Run(async () =>
        {
            if (Services != null)
            {
                var repo = Services.GetRequiredService<IDartsRepository>();
                // Lehký dotaz, který donutí Entity Framework zkompilovat modely
                await repo.GetAllPlayersAsync();
            }
        });

        // 3. Spuštění UI a původní logika aplikace
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Místo 'new MainViewModel()' si ho vytáhneme z DI kontejneru.
            // Pokud má MainViewModel v konstruktoru nějaké závislosti, kontejner je automaticky doplní.
            var mainViewModel = Services.GetRequiredService<MainViewModel>();

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel,
            };

            if (mainViewModel.Settings.PlayMusicOnStartup)
            {
                _ = SoundManagerDarts.SoundEffects.PlayDartsSong();
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}
