namespace Exercise1
{
    internal class Employee
    {

        private string code, name, date_of_birth, gender;
        private int no_of_children, salary, age;
        public string Code { get { return code; } set {  code = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int NoOfChildren { get {  return no_of_children; } set {  no_of_children = value; } }
        public int Salary { get {  return salary; } set {  salary = value; } }
        public string DateOfBirth {  get { return date_of_birth; } set { date_of_birth = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public int Age { get { return age; } set { age = value; } }     


        public Employee() {}
        public Employee(string code, string name,string date_of_birth, string gender, int no_of_children, int salary, int age)
        {
            this.code = code;
            this.name = name;
            this.date_of_birth= date_of_birth;  
            this.gender = gender;
            this.no_of_children= no_of_children;
            this.salary = salary;
            this.age = age;
        }
        public void show()
        {
            Console.WriteLine("The informations about the employee with the code " + code + " are the following:");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Date of birth: " + date_of_birth);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("Number of children: " + no_of_children);
            Console.WriteLine("Salary: " + salary);
            Console.WriteLine("Age: " + age);
            Console.WriteLine();
        }

        public int CalcIncome()
        {
            int allowance = 0;
            if(no_of_children>0)
            {
                if (no_of_children <= 2)
                    allowance = 1000000;
                else
                    allowance = 1500000;

            }
            return allowance + salary;
        }
    }
}