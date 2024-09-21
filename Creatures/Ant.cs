using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntHill.Creatures
{
    enum Ants
    {
        Forager,
        Builder,
        Caretaker
    }

    public class Ant
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Energy { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        private bool IsAlive = true;
        public World world { get; set; }
        private static Random random = new Random();

        public Ant(World world, string role, int startX, int startY)
        {
            this.world = world;
            X = startX;
            Y = startY;
            Age = 0;
            Energy = 100;
            Role = role;
            world.Grid[Y, X] = GetSymbol();
        
        }
        bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < World.Width && y >= 0 && y < World.Height;
        }
        private char GetSymbol()
        {
            return Role switch
            {
                "Forager" => 'F',
                "Builder" => 'B',
                "Caretaker" => 'C',
                _ => 'A'
            };
        }

        public void Move()
        {
            while(IsAlive)
            {
                int oldX = X; 
                int oldY = Y;

                X = Math.Clamp(X + random.Next(-1, 2), 0, World.Width - 1);
                Y = Math.Clamp(Y + random.Next(-1, 2), 0, World.Height - 1);

                world.UpdatePosition(oldX, oldY, X, Y, GetSymbol());
                
                Age++;
                Energy -= 5;

                if (Energy <= 0 || Age > 50)
                {
                    Die();
                }

               
                Thread.Sleep(1000);
            }
        }
        //private void PerformTask()
        //{
        //    switch (Role)
        //    {
        //        case "Forager":
        //            Forage();
        //            break;
        //        case "Builder":
        //            Build();
        //            break;
        //        case "Caretaker":
        //            CareForQueen();
        //            break;
        //    }
        //}

        private void Forage()
        {
            Console.WriteLine($"{Ants.Forager} {X},{Y}: Ищет еду");
            Energy += 10;
        }
        private void Build()
        {
            Console.WriteLine($"{Ants.Builder} {X},{Y}: Строит");
            
        }

        private void CareForQueen()
        {
            Console.WriteLine($"{Ants.Caretaker} {X},{Y}: Ухаживает за маткой");
        }
        private void Die()
        {
            Console.WriteLine($"муравей Возраст: {Age}, Энергия: {Energy} Die");
            IsAlive = false;
            
            world.Grid[X,Y] = '.';
            
        }
    }
}
