using Avalonia.Controls;
using DesktopUI.ViewModels;

namespace DesktopUI.Views
{
    public partial class UpdateWindow : Window
    {
        private bool _canClose = false;

        public UpdateWindow()
        {
            InitializeComponent();
            
            var vm = new UpdateViewModel();
            
            vm.CloseAction = () => 
            {
                _canClose = true;
                this.Close();
            };
            
            DataContext = vm;
        }

        protected override void OnClosing(WindowClosingEventArgs e)
        {
            base.OnClosing(e);
            
            if (!_canClose)
            {
                e.Cancel = true;
            }
        }
    }
}