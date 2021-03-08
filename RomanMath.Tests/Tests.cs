using NUnit.Framework;
using RomanMath.Impl;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var result = Service.Evaluate("IV+II/V");
			Assert.AreEqual(0, result);
		}

		[Test]
		public void Test2()
		{
			var result = Service.Evaluate("IV + II / V");
			Assert.AreEqual(0, result);
		}

		[Test]
		public void Test3()
		{
			var result = Service.Evaluate("IV + II * V");
			Assert.AreEqual(14, result);
		}

		[Test]
		public void Test4()
		{
			var result = Service.Evaluate("IV * II - V");
			Assert.AreEqual(3, result);
		}

		[Test]
		public void Test5()
		{
			var result = Service.Evaluate("(IV * II - V)");
			Assert.AreEqual(0, result);
		}

		[Test]
		public void Test6()
		{
			var result = Service.Evaluate("IV II");
			Assert.AreEqual(0, result);
		}
	}
}