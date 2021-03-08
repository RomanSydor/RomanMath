using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RomanMath.Impl
{
	public static class Service
	{

		private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
		{
			{'I', 1},
			{'V', 5},
			{'X', 10},
			{'L', 50},
			{'C', 100},
			{'D', 500},
			{'M', 1000}
		};

		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public static int Evaluate(string expression)
        {
            if (String.IsNullOrEmpty(expression))
				return 0;

			var unsupportedCherecters = expression.Intersect(new char[] { '/', '(', ')', ',', '.', '<', '>', '!', '^', ':', ';' }).ToArray();
			if (unsupportedCherecters.Length != 0)
				return 0;

			var numbers = expression.Split(' ');
            if (numbers.Length < 3)
				return 0;
			

			var decodedExpression = String.Empty;

			for (int i = 0; i < numbers.Length; i++)
            {
				if (numbers[i] == "+" || numbers[i] == "-" || numbers[i] == "*")
				{
					decodedExpression += $" {numbers[i]} ";
					continue;
				}
				numbers[i] = DecodeRomanToInt(numbers[i]).ToString();
				decodedExpression += numbers[i];
            }

			string value = new DataTable().Compute(decodedExpression, null).ToString();
			return Convert.ToInt32(value);
		}

		private static int DecodeRomanToInt(string roman)
		{
			int number = 0;
			for (int i = 0; i < roman.Length; i++)
			{
				if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
				{
					number -= RomanMap[roman[i]];
				}
				else
				{
					number += RomanMap[roman[i]];
				}
			}
			return number;
		}
	}
}
