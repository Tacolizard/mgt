using System;
using Microsoft.Xna.Framework.Graphics;
//This class handles the creation, updating, drawing, and deletion of game objects
//it tracks game objects in a list so that all game objects can be easily updated by calling
//manager.update()
//it does the same with manager.draw()
namespace mgt.Desktop
{
    public class Manager
    {
        public World world;
        public SpriteBatch spriteBatch;
        public Game1 game;

        public Manager(Game1 game, SpriteBatch spriteBatch)
        {
            this.game = game;
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
                    this.world.contents[i].worldIndex = i;
                    return i;
                }
            }
            Console.WriteLine("Out of space for Objs.");
            return 0;
        }

        public void delObj(Obj obj)
        {
            this.world.contents[obj.worldIndex] = null;
            obj = null;
        }
    }

    public class World
    {
        public Obj[] contents = new Obj[9999];
    }
}
