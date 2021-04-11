public class BankDemo
{
	public static void Main(string[] args)
	{
		Bank bank = new Bank();
		bank.OpenAccount("0001", "zhang", "1234", 200, "saving", 0);
		bank.OpenAccount("0002", "wang", "1234", 100, "credit", 500);
		ATM atm = new ATM(bank);
		//注册事件
		//atm.BigMoneyFetched += new BigMoneyFetchedHandler(ShowBigMoneyFetched);
		
		//使用lamda表达式注册事件
		atm.BigMoneyFetched += (sender, e) => { ATM.Show("一大笔钱（" + e.Money.ToString() + "元）已被取走！"); };
		for (int i = 0; i < 5; i++)
		{
			atm.Transaction();
		}
	}
	//一大笔钱已被取走回调函数
	//static void ShowBigMoneyFetched(object sender, BigMoneyArgs e)
	//{
	//	ATM.Show("一大笔钱（" + e.Money.ToString() + "元）已被取走！");
	//}
}
