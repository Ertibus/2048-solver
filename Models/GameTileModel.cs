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
    }
}
