using MyAttributeSamples.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttributeSamples.DiscoveringMetaData
{
    public class MetaDataPrinter
    {
        private readonly Type _type;

        public MetaDataPrinter(Type type)
        {
            _type = type;
        }
        public void Print()
        {
            PrintMainInfo();
            PrintMethodInfo();
            PrintPropertyInfo();
            PrintFieldInfo();
            PrintCodeChangeHistory();
        }

        private void PrintFieldInfo()
        {
            Console.WriteLine($"**************Field Information of {_type.Name}***************");
            var FieldInfo = _type.GetFields();
            foreach (var field in FieldInfo)
            {
                Console.WriteLine($"{field.FieldType} {field.Name} ");
            }
        }

        private void PrintPropertyInfo()
        {
            Console.WriteLine($"**************Property Information of {_type.Name}***************");
            var propertyInfo=_type.GetProperties();
            foreach (var property in propertyInfo)
            {
                Console.WriteLine($"{property.PropertyType} {property.Name} ");
            }
        }

        private void PrintMethodInfo()
        {
            Console.WriteLine($"***************Method Information of {_type.Name}***************");
            var methodInfo = _type.GetMethods();
            foreach (var method in methodInfo)
            {
              
                Console.Write($"method.Name:{method.Name}(");
                var Parameters=method.GetParameters();
                foreach (var Parameter in Parameters)
                {
                    Console.Write($"{Parameter.ParameterType} {Parameter.Name}, ");
                }
                Console.WriteLine(")");
            }
          
        }

        private void PrintMainInfo()
        {
            Console.WriteLine($"***************Information of {_type.Name}***************");
            Console.WriteLine($"FullName:{_type.FullName}");
            Console.WriteLine($"AssemblyQualifiedName:{_type.AssemblyQualifiedName}");
            Console.WriteLine($"BaseType:{_type.BaseType}");
            Console.WriteLine($"Namespace:{_type.Namespace}");
            Console.WriteLine($"IsAbstract:{_type.IsAbstract}");
            Console.WriteLine($"IsEnum:{_type.IsEnum}");
            Console.WriteLine($"IsNotPublic:{_type.IsNotPublic}");
        
        }
        private void PrintCodeChangeHistory()
        {
            Console.WriteLine($"***************Change History of {_type.Name}***************");
            var attributes=_type.GetCustomAttributes(typeof(CodeChangeHistoryAttribute));
            foreach(CodeChangeHistoryAttribute attribute in attributes)
            {
                Console.WriteLine($"{attribute.ChangeDateTime}\t\t {attribute.IsBug}\t\t {attribute.Description}");
            }
        }
    }
}
