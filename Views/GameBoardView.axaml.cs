using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TwoZeroFourEight.Views
{
    public partial class GameBoardView : UserControl
    {
        public GameBoardView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
