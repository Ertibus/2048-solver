namespace TwoZeroFourEight.Models
{
    class GameTileModel
    {
        private int _number;
        public int Number
        {
            get => _number;
            set { _number = value; }
        }

        private bool _hasChanged;
        public bool HasChanged 
        {
            get => _hasChanged;
            set { _hasChanged = value; }
        }

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
