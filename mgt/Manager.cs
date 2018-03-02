using System;
using Microsoft.Xna.Framework.Graphics;

namespace mgt.Desktop
{
    public class Manager
    {
        public World world;
        public SpriteBatch spriteBatch;

        public Manager(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public World newWorld()
        {
            this.world = new World();
            return this.world;
        }

        public void update()
        {
            for (int i = 0; i < this.world.contents.Length; i++)
            {
                if (this.world.contents[i] != null)
                {
                    this.world.contents[i].update();
                }
            }
        }

        public void draw()
        {
            foreach (Obj obj in this.world.contents)
            {
                if (obj != null)
                {
                    obj.draw(this.spriteBatch);
                }
            }
        }

        public int newObj(Obj obj)
        {
            for (int i = 0; i < this.world.contents.Length; i++)
            {
                if (this.world.contents[i] == null)
                {
                    this.world.contents[i] = obj;
                    this.world.contents[i].manager = this;
                    return i;
                }
            }
            return 0;
        }
    }

    public class World
    {
        public Obj[] contents = new Obj[100];
    }
}
