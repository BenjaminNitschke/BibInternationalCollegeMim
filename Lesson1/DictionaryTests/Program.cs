using System;
using System.Collections.Generic;

namespace DictionaryTests
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("DictionaryTests");
			WriteDictionary(ToDictionary("a=1"));
		}

		private static void WriteDictionary(IDictionary<string, string> dictionary)
		{
			foreach (var pair in dictionary)
				Console.WriteLine(pair.Key + ": "+pair.Value);
		}

		public static IDictionary<string, string> ToDictionary(string input)
		{
			return new Dictionary<string, string>();
		}
	}
}
