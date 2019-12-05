using System;

namespace listApp
{
    [Serializable()]
    public class User
    {
        private string _firstname;
        private string _lastname;
        private string _birthdate;
        private string _employmentdate;
        private string _role;



        public User() { }


        public User(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.role = "none";
        }


        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }


        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }


        public string birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }


        public string employmentdate
        {
            get { return _employmentdate; }
            set { _employmentdate = value; }
        }


        public string role
        {
            get { return _role; }
            set { _role = value; }
        }


        public override string ToString()
        {
            return string.Format("{0} {1}", this.firstname, this.lastname);
        }
    }
}