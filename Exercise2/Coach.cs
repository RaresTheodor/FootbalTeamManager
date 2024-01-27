using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class Coach:TeamMember
    {
        private int years_of_experience;

        public int Years_of_experience { get => years_of_experience; set => years_of_experience = value; }

        public override void Show()
        {
            Console.WriteLine($"Informations about the coach with the code {Code}:");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Adress: " + Address);
            Console.WriteLine("Position: " + Position);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Years of experience: " + Years_of_experience);
            Console.WriteLine();
        }
    }
}
