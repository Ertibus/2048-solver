using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TwoZeroFourEight.Models;

namespace TwoZeroFourEight.ViewModels
{
    class GameBoardViewModel : ViewModelBase
    {
        public ObservableCollection<GameTileModel> Items { get; set; }

        public GameBoardViewModel()
        {
            List<GameTileModel> items = new List<GameTileModel>();
            Items = new ObservableCollection<GameTileModel>(items);
        }
    }
}
