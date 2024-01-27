namespace Exercise2
{
    internal abstract class TeamMember
    {
        private string code, name, address, position;
        private int salary;

        public string Code { get => code; set => code = value; }

        public string GetCode () => code;
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Position { get => position; set => position = value; }
        public int Salary { get => salary; set => salary = value; }

        public abstract void Show();
    }
}
