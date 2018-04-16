using NUnit.Framework;
using System;
using System.Collections.Generic;

// Dozent: Benjamin Nitschke
// https://github.com/benjaminNitschke
namespace DictionaryTests
{
	public class Program
	{
		public static void Main()
		{
			AssertResult(ToDictionary("a=1;b=2;c=3"), new[] { "1", "2", "3" });
			AssertResult(ToDictionary("a=1;a=2"), new[] { "2" });
			AssertResult(ToDictionary("a=1;b=2"), new[] { "1", "2" });
			AssertResult(ToDictionary("a="), new[] { "" });
			Assert.Throws<Exception>(() => AssertResult(ToDictionary("=1"), new[] { "" }));
			AssertResult(ToDictionary(""), new string[] { });
			AssertResult(ToDictionary("a==1"), new[] { "=1" });
			Console.WriteLine("Finished!");
		}

		private static void AssertResult(IDictionary<string, string> result,
			string[] expectedValues)
		{
			Assert.That(result.Count, Is.EqualTo(expectedValues.Length));
			var index = 0;
			foreach (var item in result)
				Assert.That(item.Value, Is.EqualTo(expectedValues[index++]));
		}

		private static IDictionary<string, string> ToDictionary(string input)
		{
			var result = new Dictionary<string, string>();
			string[] inputs = input.Split(';');
			for (int i = 0; i < inputs.Length; i++)
			{
				if (inputs[i].Length == 3 && inputs[i].Contains("="))
				{
					string key = inputs[i].Substring(0, 1);
					string value = inputs[i].Substring(2, 1);
					if (!result.ContainsKey(key))
					{
						result.Add(key, value);
					}
					else
					{
						result[key] = value;
					}
				}
				else if (inputs[i].Length == 2 && inputs[i].Contains("="))
				{
					if (inputs[i].Substring(1, 1) == "=")
					{
						string key = inputs[i].Substring(0, 1);
						result.Add(key, "");
					}
					else
					{
						throw new Exception("Wrong!");
					}
				}
				else if (inputs[i].Length > 3 && inputs[i].Contains("="))
				{
					if (inputs[i].Substring(1, 1) == "=")
					{
						string key = inputs[i].Substring(0, 1);
						string value = inputs[i].Substring(2, inputs[i].Length - 2);
						result.Add(key, value);
					}
				}
			}
			return result;
		}
	}
}