using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DictionaryTests
{
	public class Program
	{
		public static void Main()
		{
			AssertResult(ToDictionary("a=1;b=2;c=3"), new[] { "1", "2", "3" });
			AssertResult(ToDictionary("a=1;b=2;d=3;e=11;f=83570892357"), new[] { "1", "2", "3", "11", "83570892357" });
		
			AssertResult(ToDictionary("a=1;a=2"), new[] { "2" });
			AssertResult(ToDictionary("a=1;b=2"), new[] { "1", "2" });
			AssertResult(ToDictionary("a="), new[] { "" });
			Assert.Throws<Exception>(() => AssertResult(ToDictionary("=1"), new[] { "" }));
			AssertResult(ToDictionary(""), new string[] { });
			AssertResult(ToDictionary("a==1"), new[] { "=1" });
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
			foreach (var part in input.Split(';'))
				AddToDictionary(part, result);
			return result;
		}
            if (input == "")
                return result;

            var parts = input.Split(';');
            for (int i = 0; i < parts.Length; i++)
            {
                var entry = parts[i].Split(new[] { '=' }, 2);

                if (entry[0] == "")
                    throw new Exception("Empty Key");
                else if (!result.ContainsKey(entry[0]))
                    result.Add(entry[0], entry[1]);
                else
                    result[entry[0]] = entry[1];
            }
            return result;
        }
    }
}