using MyAttributeSamples.DiscoveringMetaData;
using MyAttributeSamples.Domain;

var intPrinter =new  MetaDataPrinter(typeof(int));
var personprinter = new MetaDataPrinter(typeof(Person));
//intPrinter.Print();
//Console.WriteLine("press any key to print person info");
//Console.ReadKey();
//Console.Clear();

personprinter.Print();
Console.WriteLine("press any key to exit");
Console.ReadKey();