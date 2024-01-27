using System.Numerics;

namespace Exercise2
{
    internal class Player:TeamMember
    {
        private int shirt_number;

        public int Shirt_number { get => shirt_number; set => shirt_number = value; }

        public override void Show()
        {
            Console.WriteLine($"Informations about the player with the code {Code}:");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Adress: " + Address);
            Console.WriteLine("Position: " + Position);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Shirt number: " + Shirt_number);
            Console.WriteLine();
        }
    }
}
