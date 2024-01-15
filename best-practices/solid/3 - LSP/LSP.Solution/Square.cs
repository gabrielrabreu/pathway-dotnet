using System;

namespace LSP.Solution
{
    public class Square : Parallelogram
    {
        public Square(int height, int width) : base(height, width)
        {
            if (height != width)
            {
                throw new ArgumentException("Height and width must be equal.");
            }
        }
    }
}
