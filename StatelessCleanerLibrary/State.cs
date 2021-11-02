namespace StatelessCleanerLibrary
{
    public class State
    {
        public Position Position { get; set; }

        private int _angleInDegrees;

        public int AngleInDegrees
        {
            get => _angleInDegrees;
            set
            {
                if (value > 360)
                {
                    _angleInDegrees = value % 360;
                }
                else if (value < 0)
                {
                    var temp = value;
                    while (temp < 0)
                    {
                        temp = 360 + temp;
                    }
                    _angleInDegrees = temp;
                }
                else
                {
                    _angleInDegrees = value;
                }
            }
        }
        
        public Tools Tool { get;set; }
    }
}