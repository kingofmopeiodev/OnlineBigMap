using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBigMap
{
    internal class Counter
    {
        int counter_index = 0;
        int counterTimer = Game.GameTime;

        public bool finished;
        public int secondsToCount;

        public Counter(int secondsToCount)
        {
            this.secondsToCount = secondsToCount;
        }

        public void Count()
        {
            switch (counter_index)
            {
                case 0:
                    if (secondsToCount != 0 && counterTimer < Game.GameTime)
                    {
                        secondsToCount--;
                        counterTimer = Game.GameTime + 1000;
                    }
                    if (secondsToCount == 0)
                    {
                        counter_index = 1;
                    }
                    break;
                case 1:
                    this.finished = true;
                    break;
            }
        }
        public void Reset()
        {
            counter_index = 0;
            this.finished = false;
        }
    }
}
