using MyAttributeSamples.CustomAttributes;
using System.Diagnostics;

namespace MyAttributeSamples.Domain;
[DebuggerDisplay("person name is{FirstName} and his/her Age is{Age}")]
[DebuggerTypeProxy(typeof(PersonDebuggerTypeProxy))]
[CodeChangeHistory("Bahareh",isBug:false,Description ="add new property with Name..... ")]
[CodeChangeHistory("Bahareh", isBug: true, Description = "add new property with Name..... ")]
public class Person
    {
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string FirstName { get; set; } = "Bahareh";
    public string LastName { get; set; } = "Boroumand";
        public int Age { get; set; }
    public void Print()
    {
    Console.WriteLine($"{FirstName} {LastName}");
    }
    public void InputPrint(string s)
    {
        Console.WriteLine($"{s}");
    }
}


