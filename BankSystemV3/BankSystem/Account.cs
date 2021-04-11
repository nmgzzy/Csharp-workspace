using System;

interface IAccount
{
	bool SaveMoney(double money);
	bool WithdrawMoney(double money);
}

public class Account: IAccount
{
	protected double money;
	protected string id;
	protected string pwd;
	protected string name;

	public Account(string id, string name, string pwd, double money)
	{
		if (money < 0) throw new Exception("金额必须大于0");
		this.id = id;
		this.name = name;
		this.pwd = pwd;
		this.money = money;
	}

	public double Money
    {
		get
        {
			return money;
        }
        set 
		{
			if(value > 0)
            {
				money = value;
            }
		}
    }

	public string Id
	{
		get
		{
			return id;
		}
	}

	public string Pwd
	{
		get
		{
			return pwd;
		}
		set
		{
			if (value.Length > 6)
			{
				pwd = value;
			}
		}
	}

	public bool SaveMoney(double money)
	{
		if (money < 0)
		{
			return false;  //卫语句
		}
		this.money += money;
		return true;
	}

	public virtual bool WithdrawMoney(double money)
	{
		if (this.money >= money)
		{
			this.money -= money;
			return true;
		}
		return false;
	}

	public bool IsMatch(string id, string pwd)
	{
		return id == this.id && pwd == this.pwd;
	}

}

public class CreditAccount : Account, IAccount
{
	private double creditLimit;
	public CreditAccount(string id, string name, string pwd, double money, double creditLimit) : base(id, name, pwd, money)
	{
		if (money < 0) throw new Exception("金额必须大于0");
		this.creditLimit = -Math.Abs(creditLimit);
	}
	public double CreditLimit
	{
		get
		{
			return -creditLimit;

		}
		set
		{
			creditLimit = -Math.Abs(value);
		}
	}
	public override bool WithdrawMoney(double money)
	{
		if (this.money - money >= this.creditLimit)
		{
			this.money -= money;
			return true;
		}
		return false;
	}
}

