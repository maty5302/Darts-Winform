using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DesktopUI.ViewModels;

namespace DesktopUI.Views
{
    public partial class PlayerCardView : UserControl
    {
        public PlayerCardView()
        { 
            InitializeComponent();
        }
        
        protected override void OnDataContextChanged(EventArgs e)
        {
            base.OnDataContextChanged(e);

            if (DataContext is PlayerViewModel vm)
            {
                vm.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == nameof(PlayerViewModel.IsActive))
                    {
                        if (vm.IsActive)
                        {
                            FocusTextBox();
                        }
                    }
                };
                if (vm.IsActive)
                {
                    FocusTextBox();
                }
            }
        }

        private void FocusTextBox()
        {
            var textBox = this.FindControl<TextBox>("InputBox");
            textBox?.Focus();
        }
    }
}