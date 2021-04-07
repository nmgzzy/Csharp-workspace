using System;
using System.Collections;

public class ATM
{
	private Bank bank;
	private enum option
    {
		display=1,
		save,
		withdraw
    }
	public ATM(Bank bank)
	{
		this.bank = bank;
	}

	public void Transaction()
	{
		Show("please insert your card");
		string id = GetInput();

		Show("please enter your password");
		string pwd = GetInput();

		Account account = bank.FindAccount(id, pwd);	
		
		if (account == null)
		{
			Show("card invalid or password not corrent");
			return;
		}

		Show("1: display; 2: save; 3: withdraw");
		option op;
		try
        {
			op = (option)int.Parse(GetInput());
		}
        catch (Exception)
        {
			Show("input error");
			return;
		}
		
        if (op == option.display)
		{
			Show("balance: " + account.Money);
		}
		else if (op == option.save)
		{
			Show("save money");
			string smoney = GetInput();
			double money = double.Parse(smoney);

			bool ok = account.SaveMoney(money);
			if (ok)
			{
				Show("ok");
			}
			else
			{
				Show("不能存入负数");
			}

			Show("balance: " + account.Money);
		}
		else if (op == option.withdraw)
		{
			Show("withdraw money");
			string smoney = GetInput();
			double money = double.Parse(smoney);

			bool ok = account.WithdrawMoney(money);
			if (ok) Show("ok");
			else Show("余额不足");

			Show("balance: " + account.Money);
		}
		Console.WriteLine("\n");
	}


	public static void Show(string msg)
	{
		Console.WriteLine(msg);
	}
	public static string GetInput()
	{
		return Console.ReadLine();// 输入字符
	}
}
