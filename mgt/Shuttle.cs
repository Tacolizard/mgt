using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace mgt.Desktop
{
    public class Shuttle : Obj
    {
        public float speed = 1.5f;
        public int score = 100;
        public int cycles = 0;
        public Laser laser = new Laser();

        public Shuttle()
            : base() //equivalent to ..() in DM, but only works on constructors
        {
            this.path = "shuttle";
            this.hasPhysics = true;
            this.x = 200f;
            this.y = 200f;
            this.mass = 0.01f;
        }

        public override void update()
        {
            base.update();

            KeyboardState state = Keyboard.GetState();

            Random rnd = new Random();

            if (state.IsKeyDown(Keys.Up))
            {
                applyForce(new Vector2(0, -speed));
            }
            if (state.IsKeyDown(Keys.Down))
            {
                applyForce(new Vector2(0, speed));
            }

            if (state.IsKeyDown(Keys.Left))
            {
                applyForce(new Vector2(-speed, 0));
            }
            if (state.IsKeyDown(Keys.Right))
            {
                applyForce(new Vector2(speed, 0));
            }

            if (state.IsKeyDown(Keys.Space))
            {
                this.cycles++;
                if (this.cycles % laser.fireRate == 0)
                {
                    float angle = rnd.Next(-5, 5);
                    Laser laser = (Laser) this.manager.world.contents[this.manager.newObj(new Laser(this.x + 60, this.y-50))];
                    laser.angle = angle;
                    laser.applyForce(new Vector2(angle, -30));
                }
            }
        }
    }
}
