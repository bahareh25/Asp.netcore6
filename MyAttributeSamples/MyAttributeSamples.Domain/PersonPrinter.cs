using System.Diagnostics;

namespace MyAttributeSamples.Domain
{
    public class PersonPrinter
    {
        private readonly Person _person;

        public PersonPrinter(Person person)
        {
          _person = person;
        }

        public void Print()
        {
            ShowDebagdata();
            ShowDeveloperName();
            PrintFullName();
            PrintAge();
        }
        [Conditional("DEBUG")]
        private void ShowDebagdata()
        {
            Console.WriteLine("This application compiled in  debug mode ");
        }
        [Conditional("Bahareh")]
        private void ShowDeveloperName()
        {
            Console.WriteLine("Developer Name is Bahareh ");
        }

        private void PrintFullName()
        {
            Console.WriteLine($"FullName:{_person.FirstName}, {_person.LastName}");
        }
        //  [Obsolete(message:"printAge() will be Remove",error:true)]
        [Obsolete(message: "printAge() will be Remove")]
        public void PrintAge()
        {
            Console.WriteLine($"Age:{_person.Age}");
        }

        
    }
}