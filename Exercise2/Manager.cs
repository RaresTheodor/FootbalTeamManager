using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise2
{
    internal class Manager
    {
        private List<Player> players = new List<Player>();
        private List<Coach> coaches = new List<Coach>();

        public void InputPList()
        {


            string filepath = "C:\\Users\\bdiac\\Desktop\\C#\\Exercise2\\Exercise2\\PlayersFile.txt";
            StreamReader reader = new StreamReader(filepath);
            string line;
            int lineIndex = 1;

            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                if (fields.Length == 6)
                {
                    Player player = new Player();
                    player.Code = fields[0];
                    player.Name = fields[1];
                    player.Address = fields[2];
                    player.Position = fields[3];
                    player.Salary = Convert.ToInt32(fields[4]);
                    player.Shirt_number = Convert.ToInt32(fields[5]);
                    players.Add(player);
                }
                else
                    Console.WriteLine($"The line with the index {lineIndex + 1} is not correct written.Skipping this line.");
                lineIndex++;
            }
            reader.Close();
        }

        public void InputCList()
        {

            string filepath = "C:\\Users\\bdiac\\Desktop\\C#\\Exercise2\\Exercise2\\CoachesFile.txt";
            StreamReader reader = new StreamReader(filepath);
            string line;
            int lineIndex = 1;

            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                if (fields.Length == 6)
                {
                    Coach coach = new Coach();
                    coach.Code = fields[0];
                    coach.Name = fields[1];
                    coach.Address = fields[2];
                    coach.Position = fields[3];
                    coach.Salary = Convert.ToInt32(fields[4]);
                    coach.Years_of_experience = Convert.ToInt32(fields[5]);
                    coaches.Add(coach);
                }
                else
                    Console.WriteLine($"The line with the index {lineIndex + 1} is not correct written.Skipping this line.");
                lineIndex++;
            }
            reader.Close();
        }
        public void ShowPList()
        {
            foreach (Player player in players)
                player.Show();
        }
        public void ShowCList()
        {
            foreach (Coach coach in coaches)
                coach.Show();
        }



        public void ChangeInformation()
        {
            int playercode;
            int coachcode;
            Console.WriteLine("Do you want to change information about a player or about a coach?");
            Console.WriteLine("Press 1 for player; press 2 for coach");

            bool exit1 = false;
            while (!exit1)
            {
                ConsoleKeyInfo tasta = Console.ReadKey(intercept: true);
                switch (tasta.Key)
                {
                    case ConsoleKey.D1:
                        exit1 = true;
                        Console.WriteLine($"Write the player's code(a number between {players[0].Code} and {players[players.Count - 1].Code})");
                        playercode = Convert.ToInt32(Console.ReadLine());
                        bool ok = false;
                        foreach (Player player in players)
                        {

                            if (playercode == Convert.ToInt32(player.Code))
                            {
                                ok = true;
                                Console.WriteLine("What information about this player do you want to change?");
                                Console.WriteLine("Press 1 for salary; press 2 for shirt number");

                                bool exit = false;
                                while (!exit)
                                {
                                    tasta = Console.ReadKey(intercept: true);
                                    switch (tasta.Key)
                                    {
                                        case ConsoleKey.D1:
                                            Console.WriteLine("Write the new salary.");
                                            int salary = Convert.ToInt32(Console.ReadLine());
                                            player.Salary = salary;
                                            exit = true;
                                            break;
                                        case ConsoleKey.D2:
                                            Console.WriteLine("Write the new shirt number.");
                                            int shirt_number = Convert.ToInt32(Console.ReadLine());
                                            player.Shirt_number = shirt_number;
                                            exit = true;
                                            break;
                                        default:
                                            Console.WriteLine("Invalid input.Press 1 or 2.");
                                            break;
                                    }
                                }
                            }

                        }
                        if (ok == false)
                        {
                            Console.WriteLine($"The player with the code {playercode} doesn't exist.");
                            return;
                        }
                        break;
                    case ConsoleKey.D2:
                        exit1 = true;
                        Console.WriteLine($"Write the coach code(a number between {coaches[0].Code} and {coaches[coaches.Count - 1].Code})");
                        coachcode = Convert.ToInt32(Console.ReadLine());
                        ok = false;
                        foreach (Coach coach in coaches)
                        {
                            if (coachcode == Convert.ToInt32(coach.Code))
                            {
                                ok = true;
                                Console.WriteLine("Write the new salary.");
                                coach.Salary = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (ok == false)
                        {
                            Console.WriteLine($"The coach with the code {coachcode} does not exist.");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid key.Press 1 or 2.");
                        break;

                }
            }
            Console.WriteLine("The informations were updated succesfully!");
            Console.WriteLine();
            UpdateCoachesList();
            UpdatePlayersList();
        }
        public void UpdatePlayersList()
        {
            string filepath = "C:\\Users\\bdiac\\Desktop\\C#\\Exercise2\\Exercise2\\PlayersFile.txt";
            StreamWriter writer = new StreamWriter(filepath);
            foreach (Player player in players)
                writer.WriteLine($"{player.Code},{player.Name},{player.Address},{player.Position},{player.Salary},{player.Shirt_number}");
            writer.Close();
        }
        public void UpdateCoachesList()
        {
            string filepath = "C:\\Users\\bdiac\\Desktop\\C#\\Exercise2\\Exercise2\\CoachesFile.txt";
            StreamWriter writer = new StreamWriter(filepath);
            foreach (Coach coach in coaches)
                writer.WriteLine($"{coach.Code},{coach.Name},{coach.Address},{coach.Position},{coach.Salary},{coach.Years_of_experience}");
            writer.Close();
        }

        public void Sort()
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to sort?");
            Console.WriteLine("Press 1 for players; press 2 for coaches");
            Console.WriteLine();

            bool exit = false;
            while (!exit)
            {
                ConsoleKeyInfo tasta = Console.ReadKey(intercept: true);

                switch (tasta.Key)
                {
                    case ConsoleKey.D1:
                        exit = true;
                        Console.WriteLine();
                        Console.WriteLine("Do you want to sort them by:");
                        Console.WriteLine("1.Name");
                        Console.WriteLine("2.Position");
                        Console.WriteLine("3.Salary");
                        Console.WriteLine("4.Shirt number");
                        Console.WriteLine();

                        bool ok = false;
                        while (!ok)
                        {
                            tasta = Console.ReadKey(intercept: true);
                            switch (tasta.Key)
                            {
                                case ConsoleKey.D1:
                                    ok = true;
                                    Console.WriteLine();
                                    Console.WriteLine("How do you want to sort it?");
                                    Console.WriteLine("Press 1 for ascending; press 2 for descending.");
                                    Console.WriteLine();

                                    bool ok2 = false;
                                    while (!ok2)
                                    {
                                        tasta = Console.ReadKey(intercept: true);
                                        switch (tasta.Key)
                                        {
                                            case ConsoleKey.D1:
                                                ok2 = true;
                                                List<Player> copy = new List<Player>();
                                                copy = players.OrderBy(player => player.Name).ToList();
                                                foreach (Player player in copy)
                                                    Console.WriteLine(player.Name);
                                                break;
                                            case ConsoleKey.D2:
                                                ok2 = true;

                                                copy = players.OrderByDescending(player => player.Name).ToList();
                                                foreach (Player player in copy)
                                                    Console.WriteLine(player.Name);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input.Press 1 or 2.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    ok = true;
                                    Console.WriteLine("How do you want to sort it?");
                                    Console.WriteLine("Press 1 for ascending; press 2 for descending.");
                                    Console.WriteLine();

                                    ok2 = false;
                                    while (!ok2)
                                    {
                                        tasta = Console.ReadKey(intercept: true);
                                        switch (tasta.Key)
                                        {
                                            case ConsoleKey.D1:
                                                ok2 = true;
                                                List<Player> copy = new List<Player>();
                                                copy = players.OrderBy(player => player.Position).ToList();
                                                foreach (Player player in copy)
                                                    Console.WriteLine(player.Position + " " + player.Name);
                                                break;
                                            case ConsoleKey.D2:
                                                ok2 = true;
                                                copy = players.OrderByDescending(player => player.Position).ToList();
                                                foreach (Player player in copy)
                                                    Console.WriteLine(player.Position + " " + player.Name);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input.Press 1 or 2.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.D3:
                                    ok = true;
                                    Console.WriteLine("How do you want to sort it?");
                                    Console.WriteLine("Press 1 for ascending; press 2 for descending.");
                                    Console.WriteLine();

                                    ok2 = false;
                                    while (!ok2)
                                    {
                                        tasta = Console.ReadKey(intercept: true);
                                        switch (tasta.Key)
                                        {
                                            case ConsoleKey.D1:
                                                ok2 = true;
                                                List<Player> copy = new List<Player>();
                                                copy = players.OrderBy(player => player.Salary).ToList();
                                                foreach (Player player in copy)
                                                    Console.WriteLine(player.Salary + " " + player.Name);
                                                break;
                                            case ConsoleKey.D2:
                                                ok2 = true;

                                                copy = players.OrderByDescending(player => player.Salary).ToList();
                                                foreach (Player player in copy)
                                                    Console.WriteLine(player.Salary + " " + player.Name);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input.Press 1 or 2.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.D4:
                                    ok = true;
                                    Console.WriteLine("How do you want to sort it?");
                                    Console.WriteLine("Press 1 for ascending; press 2 for descending.");
                                    Console.WriteLine();

                                    ok2 = false;
                                    while (!ok2)
                                    {
                                        tasta = Console.ReadKey(intercept: true);
                                        switch (tasta.Key)
                                        {
                                            case ConsoleKey.D1:
                                                ok2 = true;
                                                List<Player> copy = new List<Player>();
                                                copy = players.OrderBy(player => player.Shirt_number).ToList();
                                                foreach (Player player in copy)
                                                    Console.WriteLine(player.Shirt_number + " " + player.Name);
                                                break;
                                            case ConsoleKey.D2:
                                                ok2 = true;

                                                copy = players.OrderByDescending(player => player.Shirt_number).ToList();
                                                foreach (Player player in copy)
                                                    Console.WriteLine(player.Shirt_number + " " + player.Name);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input.Press 1 or 2.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Press a number between 1 and 4.");
                                    break;
                            }
                        }


                        break;

                    case ConsoleKey.D2:
                        exit = true;
                        Console.WriteLine("Do you want to sort them by:");
                        Console.WriteLine("1.Name");
                        Console.WriteLine("2.Position");
                        Console.WriteLine("3.Salary");
                        Console.WriteLine("4.Years of experience");
                        Console.WriteLine();

                        ok = false;
                        while (!ok)
                        {
                            tasta = Console.ReadKey(intercept: true);
                            switch (tasta.Key)
                            {
                                case ConsoleKey.D1:
                                    ok = true;
                                    Console.WriteLine("How do you want to sort it?");
                                    Console.WriteLine("Press 1 for ascending; press 2 for descending.");
                                    Console.WriteLine();

                                    bool ok2 = false;
                                    while (!ok2)
                                    {
                                        tasta = Console.ReadKey(intercept: true);
                                        switch (tasta.Key)
                                        {
                                            case ConsoleKey.D1:
                                                ok2 = true;
                                                List<Coach> copy = new List<Coach>();
                                                copy = coaches.OrderBy(coach => coach.Name).ToList();
                                                foreach (Coach coach in copy)
                                                    Console.WriteLine(coach.Name);
                                                break;
                                            case ConsoleKey.D2:
                                                ok2 = true;
                                                copy = coaches.OrderByDescending(coach => coach.Name).ToList();
                                                foreach (Coach coach in copy)
                                                    Console.WriteLine(coach.Name);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input.Press 1 or 2.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    ok = true;
                                    Console.WriteLine("How do you want to sort it?");
                                    Console.WriteLine("Press 1 for ascending; press 2 for descending.");
                                    Console.WriteLine();

                                    ok2 = false;
                                    while (!ok2)
                                    {
                                        tasta = Console.ReadKey(intercept: true);
                                        switch (tasta.Key)
                                        {
                                            case ConsoleKey.D1:
                                                ok2 = true;
                                                List<Coach> copy = new List<Coach>();
                                                copy = coaches.OrderBy(coach => coach.Position).ToList();
                                                foreach (Coach coach in copy)
                                                    Console.WriteLine(coach.Position + " " + coach.Name);
                                                break;
                                            case ConsoleKey.D2:
                                                ok2 = true;
                                                copy = coaches.OrderByDescending(coach => coach.Position).ToList();
                                                foreach (Coach coach in copy)
                                                    Console.WriteLine(coach.Position + " " + coach.Name);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input.Press 1 or 2.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.D3:
                                    ok = true;
                                    Console.WriteLine("How do you want to sort it?");
                                    Console.WriteLine("Press 1 for ascending; press 2 for descending.");
                                    Console.WriteLine();

                                    ok2 = false;
                                    while (!ok2)
                                    {
                                        tasta = Console.ReadKey(intercept: true);

                                        switch (tasta.Key)
                                        {
                                            case ConsoleKey.D1:
                                                ok2 = true;
                                                List<Coach> copy = new List<Coach>();
                                                copy = coaches.OrderBy(coach => coach.Salary).ToList();
                                                foreach (Coach coach in copy)
                                                    Console.WriteLine(coach.Salary + " " + coach.Name);
                                                break;
                                            case ConsoleKey.D2:
                                                ok2 = true;
                                                copy = coaches.OrderByDescending(coach => coach.Salary).ToList();
                                                foreach (Coach coach in copy)
                                                    Console.WriteLine(coach.Salary + " " + coach.Name);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input.Press 1 or 2.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.D4:
                                    ok = true;
                                    Console.WriteLine("How do you want to sort it?");
                                    Console.WriteLine("Press 1 for ascending; press 2 for descending.");
                                    Console.WriteLine();

                                    ok2 = false;
                                    while (!ok2)
                                    {
                                        tasta = Console.ReadKey(intercept: true);
                                        switch (tasta.Key)
                                        {
                                            case ConsoleKey.D1:
                                                ok2 = true;
                                                List<Coach> copy = new List<Coach>();
                                                copy = coaches.OrderBy(coach => coach.Years_of_experience).ToList();
                                                foreach (Coach coach in copy)
                                                    Console.WriteLine(coach.Years_of_experience + " " + coach.Name);
                                                break;
                                            case ConsoleKey.D2:
                                                ok2 = true;
                                                copy = coaches.OrderByDescending(coach => coach.Years_of_experience).ToList();
                                                foreach (Coach coach in copy)
                                                    Console.WriteLine(coach.Years_of_experience + " " + coach.Name);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input.Press 1 or 2.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Press a number between 1 and 4.");
                                    break;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid input. Press 1 or 2.");
                        break;

                }
            }
            Console.WriteLine();
        }

        public void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== Main Menu =====");
            Console.WriteLine("1. Show Players List");
            Console.WriteLine("2. Show Coaches List");
            Console.WriteLine("3. Change Information");
            Console.WriteLine("4. Sort");
            Console.WriteLine("5. Clear the console");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
        }


        public void StartingProgram()
        {

            bool exit = false;
            InputPList();
            InputCList();
            while (!exit)
            {
                ShowMenu();

                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        ShowPList();
                        break;

                    case ConsoleKey.D2:
                        ShowCList();
                        break;

                    case ConsoleKey.D3:
                        ChangeInformation();
                        break;
                    case ConsoleKey.D4:
                        Sort();
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.Escape:
                        exit = true;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please choose a valid option.");
                        break;
                }


            }
        }

    }

}

