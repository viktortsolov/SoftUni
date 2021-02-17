namespace ClassroomProject
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string subject;
        public Student(string firstName, string lastName, string subject)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                value = firstName;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                value = lastName;
            }
        }
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                value = subject;
            }
        }

        public override string ToString()
        {
            return $"Student: First Name = {this.firstName}, Last Name = {this.lastName}, Subject = {this.subject}";
        }
    }
}
