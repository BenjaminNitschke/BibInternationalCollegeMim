using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DictionaryTest
{
    public class Program
    {
        public static void Main()
        {
            //AssertResult(ToDictionary("a=1;b=2;c=3"), new[] { "1", "2", "3" });
            AssertResult(ToDictionary("a=1;a=2"), new[] { "2" });
            //AssertResult(ToDictionary("a=1;;b=2"), new[] { "1", "2" });
            //AssertResult(ToDictionary("a="), new[] { "" });
            //Assert.Throws<Exception>(() => AssertResult(ToDictionary("=1"), new[] { "" }));
            //AssertResult(ToDictionary(""), new string[] { "" });
            //AssertResult(ToDictionary("a==1"), new[] { "=1" });
        }

        private static void AssertResult(IDictionary<string, string> result, string[] expectedValues)
        {
            Assert.That(result.Count, Is.EqualTo(expectedValues.Length));

            var index = 0;

            foreach (var item in result)
                Assert.That(item.Value, Is.EqualTo(expectedValues[index++]));
        }

        private static IDictionary<string, string> ToDictionary(string input)
        {
            var result = new Dictionary<string, string>();

            if (input == "") return result;

            string[] parts = input.Split(';');

            for (int i = 0; i < parts.Length; i++)
            {
                string[] values = parts[i].Split('=');

                if (parts[i] == "")
                    continue;

                if (result.ContainsKey(values[0]))
                    result[values[0]] = values[1];

                result.Add(values[0], values[1]);

                Console.WriteLine(values[0] + values[1]);
            }

            return result;
        }
    }
}
