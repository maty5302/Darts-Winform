using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using DesktopUI.ViewModels;

namespace DesktopUI.Views
{
    public partial class SettingsWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        public bool RequiresMainWindowReload { get; private set; }

        public SettingsWindow(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            InitializeComponent();
            LoadCurrentValues();
        }

        private void LoadCurrentValues()
        {
            var nameBoxes = GetPlayerNameBoxes();
            var colorPickers = GetPlayerColorPickers();

            for (int i = 0; i < 10; i++)
            {
                nameBoxes[i].Text = _mainViewModel.PlayerNames[i];
                colorPickers[i].Color = ParseHexColor(_mainViewModel.PlayerColors[i]);
            }

            SelectByTag("LanguageComboBox", _mainViewModel.CurrentLanguageCode);
            SelectByTag("WallpaperComboBox", _mainViewModel.MainBackgroundUri);
            RequireControl<ToggleSwitch>("StartupMusicToggle").IsChecked = _mainViewModel.PlayMusicOnStartup;
            RequireControl<ToggleSwitch>("Transparency").IsChecked = _mainViewModel.OpacityEnabled;
        }
        
        private void DefaultButton_OnClick(object? sender, RoutedEventArgs e)
        {
            //"#228B22"
            
        }

        private void SaveButton_OnClick(object? sender, RoutedEventArgs e)
        {
            var names = GetPlayerNameBoxes().Select(tb => tb.Text ?? string.Empty).ToList();
            var colors = GetPlayerColorPickers().Select(cp => ToHexColor(cp.Color)).ToList();
            var language = GetSelectedTag(RequireControl<ComboBox>("LanguageComboBox")) ?? "cs";
            var wallpaper = GetSelectedTag(RequireControl<ComboBox>("WallpaperComboBox"))
                            ?? "avares://DesktopUI/Assets/Backgrounds/darts-3-develop.jpg";
            var playMusicOnStartup = RequireControl<ToggleSwitch>("StartupMusicToggle").IsChecked == true;
            var opacityEnabled = RequireControl<ToggleSwitch>("Transparency").IsChecked == true;
            
            RequiresMainWindowReload = !string.Equals(language, _mainViewModel.CurrentLanguageCode, StringComparison.OrdinalIgnoreCase);
            _mainViewModel.ApplySettings(names, colors, language, wallpaper, playMusicOnStartup, opacityEnabled);
            Close();
        }

        private void CancelButton_OnClick(object? sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectByTag(string comboBoxName, string value)
        {
            var combo = RequireControl<ComboBox>(comboBoxName);

            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is ComboBoxItem item && string.Equals(item.Tag?.ToString(), value, StringComparison.OrdinalIgnoreCase))
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
        }

        private static string GetSelectedTag(ComboBox? comboBox)
        {
            if (comboBox?.SelectedItem is ComboBoxItem item && item.Tag is string value)
            {
                return value;
            }

            return string.Empty;
        }

        private List<TextBox> GetPlayerNameBoxes() =>
        [
            RequireControl<TextBox>("PlayerName1"),
            RequireControl<TextBox>("PlayerName2"),
            RequireControl<TextBox>("PlayerName3"),
            RequireControl<TextBox>("PlayerName4"),
            RequireControl<TextBox>("PlayerName5"),
            RequireControl<TextBox>("PlayerName6"),
            RequireControl<TextBox>("PlayerName7"),
            RequireControl<TextBox>("PlayerName8"),
            RequireControl<TextBox>("PlayerName9"),
            RequireControl<TextBox>("PlayerName10")
        ];

        private List<ColorPicker> GetPlayerColorPickers() =>
        [
            RequireControl<ColorPicker>("PlayerColor1"),
            RequireControl<ColorPicker>("PlayerColor2"),
            RequireControl<ColorPicker>("PlayerColor3"),
            RequireControl<ColorPicker>("PlayerColor4"),
            RequireControl<ColorPicker>("PlayerColor5"),
            RequireControl<ColorPicker>("PlayerColor6"),
            RequireControl<ColorPicker>("PlayerColor7"),
            RequireControl<ColorPicker>("PlayerColor8"),
            RequireControl<ColorPicker>("PlayerColor9"),
            RequireControl<ColorPicker>("PlayerColor10")
        ];

        private static Color ParseHexColor(string hexColor)
        {
            if (Color.TryParse(hexColor, out var color))
            {
                return color;
            }

            return Color.Parse("#228B22");
        }

        private static string ToHexColor(Color color) => $"#{color.R:X2}{color.G:X2}{color.B:X2}";

        private T RequireControl<T>(string name) where T : Control
        {
            return this.FindControl<T>(name)
                   ?? throw new InvalidOperationException($"Control '{name}' was not found in SettingsWindow.");
        }
        
        public SettingsWindow() : this(new MainViewModel())
        {
        }
    }
}