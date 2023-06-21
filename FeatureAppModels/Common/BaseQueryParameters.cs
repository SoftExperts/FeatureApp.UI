namespace Models.Common
{
    public class BaseQueryParameters
    {
        private int _size = 5;

        private const int _maxSize = 50;

        public int Page { get; set; } = 1;

        public int Size
        {
            get { return _size; }
            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }
    }
}
