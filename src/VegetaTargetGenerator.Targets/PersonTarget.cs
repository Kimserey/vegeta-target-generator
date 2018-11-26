using FsCheck;
using System.Collections.Generic;
using System.Linq;

namespace VegetaTargetGeneratorCS.Targets
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class PersonTarget
    {
        //TODO Provide assembly to load

        public string Name => "person";

        public string Url => "http://172.22.88.177:5000/Persons";

        public string Method => "POST";

        public Dictionary<string, IEnumerable<string>> Header =>
            new Dictionary<string, IEnumerable<string>> {
                { "Content-Type",  new[] { "application/json" } }
            };

        public object MakeBody()
        {
            return Arb.Generate<Person>().Sample(100, 1).First();
        }

        public string[] LoadAssemblies()
        {
            return new[] {
                @"C:\Users\kimserey.lam\.nuget\packages\fscheck\2.13.0\lib\netstandard2.0\FsCheck.dll",
                @"C:\Users\kimserey.lam\.nuget\packages\fsharp.core\4.5.3\lib\net45\FSharp.Core.dll"
            };
        }
    }
}
