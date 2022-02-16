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
            items.Add(new GameTileModel(1, 1, 1));
            items.Add(new GameTileModel(2, 2, 2));
            items.Add(new GameTileModel(3, 3, 3));
            items.Add(new GameTileModel(0, 4, 0));
            items.Add(new GameTileModel(0, 1, 1));
            Items = new ObservableCollection<GameTileModel>(items);
        }
    }
}
