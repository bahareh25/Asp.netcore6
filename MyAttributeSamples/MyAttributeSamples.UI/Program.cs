using MyAttributeSamples.Domain;
Person person1 = new()
{
    FirstName = "Bahareh",
    LastName = "Boroomand",
    Age = 40
};
PersonPrinter printer = new (person1);
printer.Print();
//printer.PrintAge();
Console.ReadLine();