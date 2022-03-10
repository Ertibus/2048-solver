using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TwoZeroFourEight.Views
{
    public partial class ManualGameView : UserControl
    {
        public ManualGameView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}