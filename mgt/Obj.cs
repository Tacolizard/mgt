using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mgt.Desktop
{
    public class Obj
    {

        public int x;
        public int y;
        public string path; //path to sprite
        public Texture2D sprite;
        public Manager manager;

        public bool hasPhysics = false;
        public int momentumX = 0;
        public int momentumY = 0;
        public int mass = 1;

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

                this.x += this.momentumX;
                this.y += this.momentumY;
            }
        }

        public void applyForce(int forceX, int forceY)
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
            spriteBatch.Draw(this.sprite, new Vector2(this.x, this.y), Color.White);
        }
    }
}
