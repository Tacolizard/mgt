using System;
using Microsoft.Xna.Framework;
namespace mgt.Desktop
{
    public class Invader : Obj
    {
        public Invader()
        {
            this.path = "invader";
            this.hasPhysics = true;
            this.mass = 0.5f;
            Random rnd = new Random();
            this.x = rnd.Next(-5, 5);
            this.y = rnd.Next(-5, 5);
            this.sx = 184;
            this.sy = 135;
        }

        public override void update()
        {
            base.update();
        }
    }
}
