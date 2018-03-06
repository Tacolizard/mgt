using Microsoft.Xna.Framework;
using System;

namespace mgt.Desktop
{
    public class Laser : Obj
    {
        public int cycles = 0;
        public int fireRate = 10;
        public float angle = 0f;
        public Obj firer;

        public Laser()
            :base()
        {
            sharedConstructor();
        }

        public Laser(double x, double y)
            :base()
        {
            sharedConstructor();
            this.x = x;
            this.y = y;
        }

        public void sharedConstructor()
        {
            this.path = "laser";
            this.hasPhysics = true;
            this.checkCollision = false;
            this.mass = 0;
            this.sx = 30;
            this.sy = 60;
        }

        public void fire(Obj firer, Vector2 impulse)
        {
            this.firer = firer;
            this.applyForce(impulse);
        }

        public override void update()
        {
            base.update();
            cycles++;
            if (cycles > 60)
            {
                this.manager.delObj(this);
            }
        }
    }
}
