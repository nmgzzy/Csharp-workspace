public class BankDemo
{
	public static void Main(string[] args)
	{
		Bank bank = new Bank();
		bank.OpenAccount("0001", "zhang", "1234", 200, "saving", 0);
		bank.OpenAccount("0002", "wang", "1234", 100, "credit", 500);
		ATM atm = new ATM(bank);
		//ע���¼�
		//atm.BigMoneyFetched += new BigMoneyFetchedHandler(ShowBigMoneyFetched);
		
		//ʹ��lamda���ʽע���¼�
		atm.BigMoneyFetched += (sender, e) => { ATM.Show("һ���Ǯ��" + e.Money.ToString() + "Ԫ���ѱ�ȡ�ߣ�"); };
		for (int i = 0; i < 5; i++)
		{
			atm.Transaction();
		}
	}
	//һ���Ǯ�ѱ�ȡ�߻ص�����
	//static void ShowBigMoneyFetched(object sender, BigMoneyArgs e)
	//{
	//	ATM.Show("һ���Ǯ��" + e.Money.ToString() + "Ԫ���ѱ�ȡ�ߣ�");
	//}
}
