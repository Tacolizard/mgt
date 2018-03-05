using Microsoft.Xna.Framework;

namespace mgt.Desktop
{
    public class Laser : Obj
    {
        public int cycles = 0;
        public int fireRate = 10;
        public float angle = 10f;
        public Vector2 origin = new Vector2(500 / 2f, 890/2f);

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
            this.mass = 0;
            this.sx = 30;
            this.sy = 60;
        }

        public override void update()
        {
            base.update();
            cycles++;
            if (cycles > 30)
            {
                this.manager.delObj(this);
            }
        }
    }
}
