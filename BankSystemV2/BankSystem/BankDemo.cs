public class BankDemo {
	public static void Main(string [] args)
	{
		Bank bank = new Bank();
		bank.OpenAccount("0001", "zhang", "123456", 200, "saving", 0);
		bank.OpenAccount("0002", "wang", "123456", 100, "credit", 500);
		ATM atm = new ATM(bank);
		for( int i=0; i<5; i++)
		{
			atm.Transaction();
		}
	}
	
}
