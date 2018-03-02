using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            this.x = 200;
            this.y = 200;
            this.mass = 0.1f;
        }

        public override void update()
        {
            base.update();

            KeyboardState state = Keyboard.GetState();

            Random rnd = new Random();

            if (state.IsKeyDown(Keys.Up))
            {
                //this.y -= Math.Abs(speed);
                applyForce(0, -speed);
            }
            if (state.IsKeyDown(Keys.Down))
            {
                //this.y += Math.Abs(speed);
                applyForce(0, speed);
            }

            if (state.IsKeyDown(Keys.Left))
            {
                //this.x -= Math.Abs(speed);
                applyForce(-speed, 0);
            }
            if (state.IsKeyDown(Keys.Right))
            {
                //this.x += Math.Abs(speed);
                applyForce(speed, 0);
            }

            if (state.IsKeyDown(Keys.Space))
            {
                this.cycles++;
                if (this.cycles % laser.fireRate == 0)
                {
                    float angle = rnd.Next(-5, 5);
                    Laser laser = (Laser) this.manager.world.contents[this.manager.newObj(new Laser(this.x + 60, this.y-50))];
                    //float angle = (float)Math.Atan2(0, 600);
                    //this.manager.world.contents[this.manager.newObj(new Laser(this.x+90, this.y))].applyForce(angle, -30);
                    laser.angle = angle;
                    laser.applyForce(angle, -3);
                    
                    //now that's a dank one-liner
                    //newObj returns an index of the obj in the world's contents array, so we use that to access the object
                    //so that we can apply force, with some random spread
                }
            }

            //Console.WriteLine(this.momentumX+" "+this.momentumY);

        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.sprite, new Vector2(this.x, this.y), Color.White);
        }

    }
}
