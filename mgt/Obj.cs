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
        public double sx = 0;//size x
        public double sy = 0;//size y
        public Vector2 origin;

        public int worldIndex; //cached index of this object
        public string path; //path to sprite
        public Texture2D sprite;
        public Manager manager;
        public bool runPostInit = true;

        public bool hasPhysics = false;
        public bool checkCollision = false;
        public Vector2 momentum;
        public float mass = 0.01f;//maximum mass is 1. 1 makes object immovable.

        public Obj()
        {
            //Console.WriteLine("obj created");
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

        public virtual void Del()
        {
            //Callback function on Obj deletion
        }

        public void postInit()
        { //function for stuff to run after initialization.
            //useful if a variable needs to be created based on
            //a value set in a child's constructor.
            this.origin = new Vector2((float)sx / 2, (float)sy / 2);
        }

        public virtual void update()
        {
            if (runPostInit)
            {
                this.postInit();
                runPostInit = false;
            }

            if (hasPhysics) 
            {

                if (checkCollision)
                {
                    for (int i = 0; i < this.manager.world.contents.Length;i++)
                    {
                        if (this.manager.world.contents[i] != null && this.manager.world.contents[i] != this)
                        {
                            Obj c = this.manager.world.contents[i];
                            if ((this.x >= c.x-(c.sx/2.0f) && this.x <= c.x+(c.sx/2.0f)) && (this.y >= c.y - (c.sy / 2.0f) && this.y <= c.y + (c.sy / 2.0f)))
                            {
                                this.collision(c);
                            }
                        } 
                    }
                }

                momentum *= (1 - mass);
                this.x += this.momentum.X;
                this.y += this.momentum.Y;
            }
        }

        public virtual void collision(Obj collideWith)
        {
            //callback function when this object collides with another
        }

        public void applyForce(Vector2 impulse)
        {
            this.momentum += impulse*(1-mass);
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (runPostInit)
            {
                return; //dont draw until postInit has run
            }

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
                spriteBatch.Draw(sprite, new Rectangle((int)x-(int)origin.X, (int)y-(int)origin.Y, (int)sx, (int)sy), Color.White);
            }
        }
    }
}
