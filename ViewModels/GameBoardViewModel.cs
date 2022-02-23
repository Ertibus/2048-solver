using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TwoZeroFourEight.Models;

namespace TwoZeroFourEight.ViewModels
{
    class GameBoardViewModel : ViewModelBase
    {

        public GameBoardViewModel()
        {
            List<GameTileModel> items = new List<GameTileModel>();
            Width = 400;
            Height = 400;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    items.Add(new GameTileModel(i, j, i * 10 + j));
                }
            }
            Items = new ObservableCollection<GameTileModel>(items);
        }

        public ObservableCollection<GameTileModel> Items { get; }
        public int Width{ get; }
        public int Height{ get; }
    }
}
