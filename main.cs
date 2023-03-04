using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBigMap
{
    public class main : Script
    {
        bool bigMapActive = false;
        Counter MapCounter = new Counter(5);
        public main()
        {
            Tick += onTick;
            Aborted += onShutDown;
        }
        public void onTick(object sender, EventArgs e)
        {
            if (bigMapActive)
            {
                if (!MapCounter.finished)
                {
                    MapCounter.Count();
                }
                else
                {
                    Function.Call(Hash.SET_BIGMAP_ACTIVE, false, false);
                    bigMapActive = false;
                    MapCounter.Reset();
                    MapCounter = new Counter(5);
                }
            }
            if(Game.IsControlJustPressed(GTA.Control.HUDSpecial))
            {
                if (!bigMapActive)
                {
                    Function.Call(Hash.SET_BIGMAP_ACTIVE, true, false);
                    bigMapActive = true;
                }
                else
                {
                    Function.Call(Hash.SET_BIGMAP_ACTIVE, false, false);
                    bigMapActive = false;
                    MapCounter.Reset();
                    MapCounter = new Counter(5);
                }
            }
        }
        public void onShutDown(object sender, EventArgs e)
        {
            Function.Call(Hash.SET_BIGMAP_ACTIVE, false, false);
        }
    }
}
