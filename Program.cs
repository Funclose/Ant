using AntHill.Creatures;

namespace AntHill
{
     class Program
    {
        static void Main(string[] args)
        {
           World world = new World();
           Colony colony = new Colony(world);
            colony.AddAnt(new Ant(world, "Forager", 5, 5));
            colony.AddAnt(new Ant(world, "Builder", 10, 10));
            colony.AddAnt(new Ant(world, "Caretaker", 15, 15));

            colony.RunColony();
            
        }
    }
}
