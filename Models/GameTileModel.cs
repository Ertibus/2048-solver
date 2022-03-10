namespace TwoZeroFourEight.Models
{
    class GameTileModel
    {
        public static int TILE_SIZE = 100;
        public static int PADDING = 10;

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
            get => _posX * (TILE_SIZE + PADDING);
            set { _posX = value; }
        }

        public int PosY
        {
            get => _posY * (TILE_SIZE + PADDING);
            set { _posY = value; }
        }

        public string Color
        {
            get => GetColor(_number);
        }
        public string FgColor
        {
            get => GetFontColor(_number);
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
                    return "#aaffff";
                case 4:
                    return "#55aaaa";
                case 8:
                    return "#44ffff";
                case 16:
                    return "#44a4ff";
                case 32:
                    return "#7777ff";
                case 64:
                    return "#aaaaff";
                case 128:
                    return "#eeeeff";
                case 256:
                    return "#dddd77";
                case 512:
                    return "#dda777";
                case 1024:
                    return "#dd7777";
                case 2048:
                    return "#ff6666";
                case 4096:
                    return "#ff4466";
                case 8192:
                    return "#699999";
                default:
                    return "#aaaaaa";
            }
        } 
        public string GetFontColor(int n)
        {
            switch(n)
            {
                case 0:
                    return "#eeeeee";
                default:
                    return "#000000";
            }
        }
    }
}
