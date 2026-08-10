using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using DesktopUI.ViewModels;

namespace DesktopUI.Views
{
    public partial class PlayerCardView : UserControl
    {
        private PlayerViewModel? _viewModel;

        public PlayerCardView()
        { 
            InitializeComponent();
        }
        
        protected override void OnDataContextChanged(EventArgs e)
        {
            base.OnDataContextChanged(e);

            if (_viewModel != null)
            {
                _viewModel.PropertyChanged -= OnViewModelPropertyChanged;
            }

            _viewModel = DataContext as PlayerViewModel;
            if (_viewModel == null)
            {
                return;
            }

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
            if (_viewModel.IsActive)
            {
                FocusTextBox();
            }
        }

        private void OnViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PlayerViewModel.IsActive) && _viewModel?.IsActive == true)
            {
                FocusTextBox();
            }
        }

        private void FocusTextBox()
        {
            Dispatcher.UIThread.Post(() =>
            {
                var textBox = this.FindControl<TextBox>("InputBox");
                if (textBox?.IsEnabled == true)
                {
                    textBox.Focus();
                    textBox.SelectAll();
                }
            });
        }

        private void InputBox_OnGotFocus(object? sender, RoutedEventArgs e)
        {
            if (DataContext is PlayerViewModel vm)
            {
                vm.NotifyInputFocused();
            }
        }
    }
}