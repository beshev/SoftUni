namespace _07.CustomException
{
    class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (NameValidator(value))
                {
                    throw new InvalidPersonNameException("Name must contains only letters");
                }
                this.name = value;
            }
        }

        public string Email { get; set; }

        private bool NameValidator(string value)
        {
            foreach (var symbol in value)
            {
                if (char.IsLetter(symbol) == false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
