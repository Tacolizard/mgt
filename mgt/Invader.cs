using System;
using Microsoft.Xna.Framework;
namespace mgt.Desktop
{
    public class Invader : Obj
    {
        public int cycles = 0;

        public Invader()
            :base()
        {
            this.path = "invader";
            this.hasPhysics = true;
            this.checkCollision = true;
            this.mass = 0.1f;
            Random rnd = new Random();
            this.x = rnd.Next(50, 1280);
            this.y = rnd.Next(50, 720);
            this.sx = 184;
            this.sy = 135;
        }

        public override void collision(Obj collideWith)
        {
            base.collision(collideWith);

            Console.WriteLine("collided");

            if (collideWith.GetType() == typeof(Laser))
            {
                Laser l = (Laser)collideWith;
                if (l.firer.GetType() == typeof(Shuttle))
                {
                    Shuttle s = (Shuttle)l.firer;
                    s.score += 50;
                    this.manager.delObj(collideWith);
                    this.manager.delObj(this);
                }
            }
        }

        public override void update()
        {
            base.update();
            cycles++;

            if (cycles % 30 == 0)
            {
                Random rnd = new Random();
                this.applyForce(new Vector2(rnd.Next(-30, 30), rnd.Next(-30, 30)));
            }

        }
    }
}
