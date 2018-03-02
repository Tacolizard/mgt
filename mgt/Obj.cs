using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//this is the base class for all game objects
//it provides some useful variables and 
//virtual update and draw functions that are overridden by children if required
//it also implements a very crude physics system that should be put onto its own object
//the manager deals with objects of this type.

namespace mgt.Desktop
{
    public class Obj
    {

        public int x;
        public int y;
        public int sx = 0;//size x
        public int sy = 0;//size y

        public int worldIndex; //cached index of this object
        public string path; //path to sprite
        public Texture2D sprite;
        public Manager manager;

        public bool hasPhysics = false;
        public float momentumX = 0;
        public float momentumY = 0;
        public float mass = 1;

        public Obj()
        {
            Console.WriteLine("obj created");
            this.x = 200;
            this.y = 200;
        }

        public Obj(Texture2D sprite)
        {
            this.sprite = sprite;
            this.x = 200;
            this.y = 200;
        }

        public Obj(Texture2D sprite, int x, int y)
        {
            this.sprite = sprite;
            this.x = x;
            this.y = y;
        }

        public virtual void update()
        {
            if (hasPhysics) 
            {
                if (this.momentumX > 0)
                {
                    this.momentumX -= this.mass;
                }
                if (this.momentumX < 0)
                {
                    this.momentumX += this.mass;
                }
                if (this.momentumY > 0)
                {
                    this.momentumY -= this.mass;
                }
                if (this.momentumY < 0)
                {
                    this.momentumY += this.mass;
                }

                this.x += (int) this.momentumX;
                this.y += (int) this.momentumY;
            }
        }

        public void applyForce(float forceX, float forceY)
        {
            this.momentumX += forceX;
            this.momentumY += forceY;
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (this.sprite == null)
            {
                Console.WriteLine("Runtime error: attempted to draw an obj with no sprite");
                return;
            }

            if (this.sx == 0 && this.sy == 0)
            {
                spriteBatch.Draw(this.sprite, new Vector2(this.x, this.y), Color.White);
            } else
            {
                spriteBatch.Draw(sprite, new Rectangle(x, y, sx, sy), Color.White);
            }
        }
    }
}
