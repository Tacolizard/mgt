using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace mgt.Desktop
{
    public class Laser : Obj
    {
        public int speed = 5;

        public Laser()
            :base()
        {
            this.path = "laser";
        }

        public Laser(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override void update()
        {
            base.update();
            this.y -= this.speed;
        }
    }
}
