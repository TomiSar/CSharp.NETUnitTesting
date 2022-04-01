using System;

namespace BankAccountNS
{
	/// <summary>
	/// Bank account demo class.
	/// </summary>
	public class BankAccount
	{
		private readonly string m_customerName;
		private double m_balance;
		public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
		public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
		public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

		private BankAccount() { }

		public BankAccount(string customerName, double balance)
		{
			m_customerName = customerName;
			m_balance = balance;
		}

		public string CustomerName
		{
			get { return m_customerName; }
		}

		public double Balance
		{
			get { return m_balance; }
		}

		public void Debit(double amount)
		{
			if (amount > m_balance)
			{
				throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
			}
			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
			}
			m_balance -= amount;
		}

		public void Credit(double amount)
		{
			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
			}
			m_balance -= amount;
		}

		public void AddMoneyToAccount(double amount)
		{
			if (amount < 0 )
			{
				throw new ArgumentOutOfRangeException("amount");
			}
			m_balance += amount;
		}

		public void PrintBalance(BankAccount ba)
		{
			Console.WriteLine("Current balance is {0}$", ba.Balance);
		}

		static void Main(string[] args)
		{
			BankAccount ba = new BankAccount("Mr. Chuck Norris", 11.99);
			ba.Debit(5.77);
			ba.Credit(11.22);
			ba.PrintBalance(ba);

			//ba.AddMoneyToAccount(-100);
			//ba.PrintBalance(ba);
		}
	}
}
