using System;
using System.Collections;

//一大笔钱已被取走委托
public delegate void BigMoneyFetchedHandler(object sender, BigMoneyArgs e);

public class BigMoneyArgs
{
	public double Money;
	public BigMoneyArgs(double money)
    {
		this.Money = money;
    }
}

public class BadCashException : ApplicationException
{
	public BadCashException(string message)
		: base(message)
	{ }
}

public class ATM
{
	private Bank bank;
	public event BigMoneyFetchedHandler BigMoneyFetched;
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
	//随机抛出坏币异常
	private void save(Account account)
    {
		string smoney = GetInput();
		double money = double.Parse(smoney);
		Random rnd = new Random();
		if(rnd.Next(3)<1)
        {
			throw new BadCashException("bad cash");
		}
        else
        {
			bool ok = account.SaveMoney(money);
			if (ok)
			{
				Show("ok");
			}
			else
			{
				Show("不能存入负数");
			}
		}
	}
	private void withdraw(Account account)
	{
		string smoney = GetInput();
		double money = double.Parse(smoney);

		bool ok = account.WithdrawMoney(money);
		if (ok)
		{
			Show("ok");
			//大于10000发布委托
			if (money > 10000)
			{
				BigMoneyFetched(this, new BigMoneyArgs(money));
			}
		}
		else
		{
			Show("余额不足");
		}
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
			try
            {
				this.save(account);
			}
			catch(BadCashException)
            {
				Show("bad cash");
            }
			Show("balance: " + account.Money);
		}
		else if (op == option.withdraw)
		{
			Show("withdraw money");
			this.withdraw(account);
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
