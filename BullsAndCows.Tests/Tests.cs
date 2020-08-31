using NUnit.Framework;

namespace BullsAndCows.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(3)]
		public void Should_Be_n_Characters_Long(int numberOfDigits)
		{
			var number = Digits.GetRandomNumber(numberOfDigits);
			Assert.AreEqual(numberOfDigits, number.Length);
		}

		[TestCase("427", "123", 1, 0, 3)]
		[TestCase("155", "123", 1, 0, 3)]
		[TestCase("258", "123", 0, 1, 3)]
		[TestCase("456", "358", 1, 0, 3)]
		[TestCase("897", "897", 3, 0, 3)]
		[TestCase("763", "146", 0, 1, 3)]
		[TestCase("567", "675", 0, 3, 3)]
		[TestCase("123456", "123789", 3, 0, 6)]
		public void Should_Count_Bulls_And_Cows_Correctly(string secret, string guess, int expectedBulls, int expectedCows, int numberOfDigits)
		{
			Game game = new Game(numberOfDigits);
			var counts = game.CountBullsAndCows(secret, guess);
			Assert.AreEqual(expectedBulls, counts.Bulls);
			Assert.AreEqual(expectedCows, counts.Cows);
		}

		[TestCase("123", true, 3)]
		[TestCase("111", false, 3)]
		[TestCase("464", false, 3)]
		[TestCase("123456", true, 6)]
		public void HasUniqueDigits(string possibility, bool expected, int numberOfDigits)
		{
			bool isUnique = Digits.HasUniqueDigits(possibility, numberOfDigits);
			Assert.AreEqual(expected, isUnique);
		}

		private const string DomainErrorMessage = "Please enter a number between 3 and 5.";
		private const string ParseErrorMessage = "Please enter a single digit.";

		[TestCase(true, "3", null)]
		[TestCase(true, "4", null)]
		[TestCase(true, "5", null)]
		[TestCase(false, "123456789999", ParseErrorMessage)]
		[TestCase(false, "asdf", ParseErrorMessage)]
		[TestCase(false, "///", ParseErrorMessage)]
		[TestCase(false, "10", DomainErrorMessage)]
		[TestCase(false, "123456", DomainErrorMessage)]
		public void Should_Be_Digits(bool expectedOutcome, string numberOfDigitsString, string expectedErrorMessage)
		{
			var validationResult = Program.ValidateNumberOfDigits(out int _, numberOfDigitsString);
			Assert.AreEqual(expectedOutcome, validationResult.Success);
			if (!validationResult.Success)
			{
				Assert.AreEqual(expectedErrorMessage, validationResult.Error);
			}
		}
	}
}
