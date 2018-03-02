using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mgt.Desktop
{
    public class Shuttle : Obj
    {
        public int speed = 5;
        public int score = 100;

        public Shuttle()
            :base() //equivalent to ..() in DM, but only works on constructors
        {
            this.path = "shuttle";
            this.hasPhysics = true;
            this.x = 200;
            this.y = 200;
        }

        public override void update()
        {
            base.update();

            KeyboardState state = Keyboard.GetState();

            Random rnd = new Random();

            if (state.IsKeyDown(Keys.Up))
            {
                //this.y -= Math.Abs(speed);
                applyForce(0, -3);
            }
            if (state.IsKeyDown(Keys.Down))
            {
                //this.y += Math.Abs(speed);
                applyForce(0, 3);
            }

            if (state.IsKeyDown(Keys.Left))
            {
                //this.x -= Math.Abs(speed);
                applyForce(-3, 0);
            }
            if (state.IsKeyDown(Keys.Right))
            {
                //this.x += Math.Abs(speed);
                applyForce(3, 0);
            }

            if (state.IsKeyDown(Keys.Space))
            {
                this.manager.newObj(new Laser());
            }

            Console.WriteLine(this.momentumX+" "+this.momentumY);

        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.sprite, new Vector2(this.x, this.y), Color.White);
        }

    }
}
