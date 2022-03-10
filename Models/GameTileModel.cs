namespace TwoZeroFourEight.Models
{
    class GameTileModel
    {
        private static int TILE_SIZE = 100;

        public GameTileModel(int x, int y, int number)
        {
            _posX = x;
            _posY = y;
            _number = number;
            _hasChanged = false;
        }

        public int Number
        {
            get => _number;
            set { _number = value; }
        }

        public bool HasChanged
        {
            get => _hasChanged;
            set { _hasChanged = value; }
        }

        public int PosX
        {
            get => _posX * TILE_SIZE;
            set { _posX = value; }
        }

        public int PosY
        {
            get => _posY * TILE_SIZE;
            set { _posY = value; }
        }

        public string Color
        {
            get => GetColor(_number);
        }

        private int _number;
        private bool _hasChanged;
        private int _posX;
        private int _posY;

        public void Clear()
        {
            _number = 0;
            _hasChanged = false;
        }

        public void DoubleIt()
        {
            _number *= 2;
            _hasChanged = true;
        }

        public string GetColor(int n)
        {
            switch(n) 
            {
                case 0:
                    return "#eeeeee";
                case 2:
                    return "#ffffaa";
                case 4:
                    return "#aaffaa";
                case 8:
                    return "#aaddff";
                case 16:
                    return "#aaaaff";
                case 32:
                    return "#77ffff";
                case 64:
                    return "#7777ff";
                case 128:
                    return "#777777";
                default:
                    return "#000000";
            }
        } 
    }
}
