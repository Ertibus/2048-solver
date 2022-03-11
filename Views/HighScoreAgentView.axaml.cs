using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TwoZeroFourEight.Views
{
    public partial class HighScoreAgentView : UserControl
    {
        public HighScoreAgentView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}