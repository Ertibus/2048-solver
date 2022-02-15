using System;
using System.Collections.Generic;
using System.Text;

namespace TwoZeroFourEight.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public GameBoardViewModel GameView { get; }

        public MainWindowViewModel()
        {
            GameView = new ViewModels.GameBoardViewModel();
        }
    }
}
