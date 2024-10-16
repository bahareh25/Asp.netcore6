using System.Reflection;
var assembly = Assembly.LoadFrom(@"E:\Course\NikAmooz\ASp.net6\Session27_11\My\MyAttributeSamples\MyAttributeSamples.Domain\bin\Debug\net6.0\MyAttributeSamples.Domain.dll");
var types= assembly.GetTypes();
Console.WriteLine(assembly.FullName);
foreach (var type in types)
{
    Console.WriteLine($"{type.Name}");
}
Console.ReadLine();