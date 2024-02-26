using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstGame
{
    public class Star
    {
        
        public int PositionX;
        public int PositionY;

        public Star(int maxWidth)
        {
            PositionX = new Random().Next(maxWidth);
            PositionY = 1;
        }
    }
}