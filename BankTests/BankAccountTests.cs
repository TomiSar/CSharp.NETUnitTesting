using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankTests
{
	[TestClass]
	public class BankAccountTests
	{
		[TestMethod]
		public void Debit_WithValidAmount_UpdatesBalance()
		{
			// Arr
			double beginBalance = 11.99;
			double debitAmount = 4.57;
			double expected = 7.42;
			BankAccount bankAccount = new BankAccount("Mr. Chuck Norris", beginBalance);

			// Act
			bankAccount.Debit(debitAmount);
			double actual = bankAccount.Balance;

			// Assert
			Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
		}

		[TestMethod]
		public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			double beginBalance = 11.99;
			double debitAmount = -100.00;
			BankAccount account = new BankAccount("Mr. Chuck Norris", beginBalance);

			// Act and assert
			try
			{
				account.Debit(debitAmount);
			}
			catch (ArgumentOutOfRangeException e)
			{
				StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage); ;
			}
		}

		[TestMethod]
		public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			double beginBalance = 11.99;
			double debitAmount = 20.00;
			BankAccount account = new BankAccount("Mr. Chuck Norris", beginBalance);

			// Act
			try
			{
				account.Debit(debitAmount);
			}
			catch (ArgumentOutOfRangeException e)
			{
				// Assert
				StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage); ;
				return;
			}
			Assert.Fail("The expected exception was not thrown.");
		}

		[TestMethod]
		public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			double beginBalance = 11.99;
			double creditAmount = -100.00;
			BankAccount account = new BankAccount("Mr. Chuck Norris", beginBalance);

			// Act and assert
			try
			{
				account.Credit(creditAmount);
			}
			catch (Exception e)
			{
				StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
			}
		}

		[TestMethod]
		public void Credit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			double beginningBalance = 11.99;
			double creditAmount = 100.00;
			BankAccount account = new BankAccount("Mr. Chuck Norris", beginningBalance);

			// Act and assert
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(creditAmount));
		}



		[TestMethod]
		public void AddMoneyToAccount_DesiredAmount()
		{
			// Arr
			double beginBalance = 11.99;
			double moneyAmount = 4.57;
			double expected = 16.56;
			BankAccount bankAccount = new BankAccount("Mr. Chuck Norris", beginBalance);

			// Act
			bankAccount.AddMoneyToAccount(moneyAmount);
			double actual = bankAccount.Balance;

			// Assert
			Assert.AreEqual(expected, actual, 0.001, "Adding money to account increases balance with desired amount.");
		}

		[TestMethod]
		[Ignore]
		public void AddNegativeAmountMoneyToAccount_ShouldThrowArgumentOutOfRange()
		{
			// Arr
			double beginBalance = 11.99;
			double moneyAmount = -100.00;
			BankAccount account = new BankAccount("Mr. Chuck Norris", beginBalance);

			// Act
			account.AddMoneyToAccount(moneyAmount);

			// Act and assert
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.AddMoneyToAccount(moneyAmount));
		}
	}
}
