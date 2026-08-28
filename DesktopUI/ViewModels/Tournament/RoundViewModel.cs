using System.Collections.ObjectModel;

namespace DesktopUI.ViewModels.Tournament
{
    public class RoundViewModel
    {
        public ObservableCollection<MatchViewModel> Matches { get; set; } = new();
    }
}