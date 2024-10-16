﻿
using MyAttributeSamples.Domain;

Person _person = new Person();
Type personType01=_person.GetType();
Console.WriteLine(personType01.FullName);
Console.WriteLine(personType01.AssemblyQualifiedName);
Type personType02=typeof(Person);
Console.WriteLine(personType02.FullName);
Type personType03=Type.GetType("MyAttributeSamples.ReflectionUI.Teacher",true,true);
Console.WriteLine(personType03.FullName);
Type personType04 = Type.GetType("MyAttributeSamples.Domain.Person,MyAttributeSamples.Domain", true, true);
Console.WriteLine(personType04.FullName);
Console.ReadLine();
