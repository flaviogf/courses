using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameEngine.Test
{
    public class ExternalHealthDamageTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                using StreamReader sr = new("TestData.csv");

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    yield return line.Split(',').Cast<object>().ToArray();
                }
            }
        }
    }
}
