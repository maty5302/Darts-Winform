using System;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.Interactivity;
using DesktopUI.ViewModels;

namespace DesktopUI.Views
{
    public partial class DuelCardView : UserControl
    {
        public DuelCardView()
        {
            InitializeComponent();
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            base.OnDataContextChanged(e);

            if (DataContext is DuelViewModel vm)
            {
                if (vm.Player1 != null) vm.Player1.PropertyChanged += Player_PropertyChanged;
                if (vm.Player2 != null) vm.Player2.PropertyChanged += Player_PropertyChanged;
                
                UpdateFocus(vm);
            }
        }

        private void Player_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PlayerViewModel.IsActive))
            {
                if (DataContext is DuelViewModel vm)
                {
                    Dispatcher.UIThread.Post(() => UpdateFocus(vm));
                }
            }
        }
        
        private void UpdateFocus(DuelViewModel vm)
        {
            if (vm.Player1.IsActive)
            {
                this.FindControl<TextBox>("Player1Input")?.Focus();
            }
            else if (vm.Player2.IsActive)
            {
                this.FindControl<TextBox>("Player2Input")?.Focus();
            }
        }

        private void Player1Input_OnGotFocus(object? sender, RoutedEventArgs e)
        {
            if (DataContext is DuelViewModel vm)
                vm.Player1.NotifyInputFocused();
        }

        private void Player2Input_OnGotFocus(object? sender, RoutedEventArgs e)
        {
            if (DataContext is DuelViewModel vm)
                vm.Player2.NotifyInputFocused();
        }
    }
}