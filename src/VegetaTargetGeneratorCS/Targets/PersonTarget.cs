using FsCheck;
using System.Collections.Generic;
using System.Linq;

namespace VegetaTargetGeneratorCS.Targets
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class PersonTarget : ITarget
    {
        public string Name => "person";

        public string Url => "http://172.22.88.177:5000/Persons";

        public string Method => "POST";

        public Dictionary<string, IEnumerable<string>> Header => new Dictionary<string, IEnumerable<string>> {
            { "Content-Type",  new[] { "application/json" } }
        };

        public object MakeBody()
        {
            return Arb.Generate<Person>().Sample(100, 1).First();
        }
    }
}
