using System.Reflection;
//dynamic load assembly
var assembly = Assembly.LoadFrom(@"E:\Course\NikAmooz\ASp.net6\Session27_11\My\MyAttributeSamples\MyAttributeSamples.Domain\bin\Debug\net6.0\MyAttributeSamples.Domain.dll");
var personType = assembly.GetType("MyAttributeSamples.Domain.Person");

//LateBinding
var person=Activator.CreateInstance(personType);
Console.WriteLine($"my object type is {person}");
//var personmethods = personType.GetMethods();
//foreach (var method in personmethods)
//{
//    Console.WriteLine(method.Name);
//}
//reflection
var printMethod = personType.GetMethod("Print");
printMethod.Invoke(person, null);
var inputprint = personType.GetMethod("InputPrint");
inputprint.Invoke(person,new object[] { "this is test" });

Console.ReadLine();
