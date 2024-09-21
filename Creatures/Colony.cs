using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntHill.Creatures
{
    public class Colony
    {
        public List<Ant> ants = new List<Ant>();
        public List<Thread> threads = new List<Thread>();
        private World _world;
        public Colony(World Worlds) 
        {
            _world = Worlds;
        }

        public void AddAnt(Ant ant)
        {
            ants.Add(ant);
            Thread thread = new Thread(ant.Move);
            threads.Add(thread);
            thread.Start();
        }
        public void RunColony()
        {
            Thread ShowThread = new Thread(() =>
            {
                while (true)
                {
                    _world.Display();
                    Thread.Sleep(1000);
                }
            });
            ShowThread.Start();
            foreach(var i in threads)
            {
                i.Join();
            }
        }

    }
}
