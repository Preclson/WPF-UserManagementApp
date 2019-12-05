using System;

namespace listApp
{
    public class Regular : User
    {
        public Regular() { }

        public Regular(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.role = "User";
        }

        ~Regular()
        {
            Console.WriteLine("Regular Object Deleted!");
        }

        //public override string ToString()
        //{
        //    return string.Format("{0} {1}", this.firstname, this.lastname);
        //}
    }


    public class Manager : User
    {
        public Manager() { }

        public Manager(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.role = "Manager";
        }

        //public override string ToString()
        //{
        //    return string.Format("{0} {1}", this.firstname, this.lastname);
        //}
    }

    public class Administrator : User
    {
        public Administrator() { }

        public Administrator(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.role = "Administrator";
        }


        //public override string ToString()
        //{
        //    return string.Format("{0} {1}", this.firstname, this.lastname);
        //}
    }
}
