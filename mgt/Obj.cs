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

        public double x;
        public double y;
        public int sx = 0;//size x
        public int sy = 0;//size y

        public int worldIndex; //cached index of this object
        public string path; //path to sprite
        public Texture2D sprite;
        public Manager manager;

        public bool hasPhysics = false;
        public Vector2 momentum;
        public float mass = 0.01f;//maximum mass is 1. 1 makes object immovable.

        public Obj()
        {
            Console.WriteLine("obj created");
            this.x = 200;
            this.y = 200;
            momentum = new Vector2(0, 0);
        }

        public Obj(Texture2D sprite)
        {
            this.sprite = sprite;
            this.x = 200;
            this.y = 200;
            momentum = new Vector2(0, 0);
        }

        public Obj(Texture2D sprite, int x, int y)
        {
            this.sprite = sprite;
            this.x = x;
            this.y = y;
            momentum = new Vector2(0, 0);
        }

        public virtual void update()
        {
            if (hasPhysics) 
            {
                momentum *= (1-mass);
                this.x += this.momentum.X;
                this.y += this.momentum.Y;
            }
        }

        public void applyForce(Vector2 impulse)
        {
            this.momentum += impulse*(1-mass);
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (this.sprite == null)
            {
                Console.WriteLine("Attempted to draw an obj with no sprite");
                return;
            }

            if (this.sx == 0 && this.sy == 0)
            {
                spriteBatch.Draw(this.sprite, new Vector2((float)this.x, (float)this.y), Color.White);
            } else
            {
                spriteBatch.Draw(sprite, new Rectangle((int)x, (int)y, sx, sy), Color.White);
            }
        }
    }
}
