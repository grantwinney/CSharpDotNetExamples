using System.Xml.Linq;

namespace ListPatternMatching
{
    public class SchoolEngine
    {
        public static void PrintGrades()
        {
            // Pretend we're actually receiving XML like you might get from a SOAP API,
            // but this could just as well be JSON from a REST API...
            var xml = @"<students>
                            <student><name>Greg</name><grades>92,91,77,89,85</grades></student>
                            <student><name>Tina</name><grades>97,88,84,91,80</grades></student>
                        </students>";

            var xdoc = XDocument.Parse(xml);

            foreach (var student in xdoc.Root.Elements("student"))
            {
                var grades = student.Element("grades").Value.Split(',');
                if (grades is [var math, _, var art, .. { Length: 2 }])
                {
                    var name = student.Element("name").Value;
                    Console.WriteLine($"{name} got a {math}% in math and a {art}% in art.");
                    Console.WriteLine($"The average for all subjects was: {grades.Select(decimal.Parse).Sum() / 4}%");
                }
            }
        }
    }
}
