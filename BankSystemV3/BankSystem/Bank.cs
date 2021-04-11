using System;
using System.Collections;
using System.Collections.Generic;

public class Bank
{
	private List<Account> accounts = new List<Account>();

	public Account OpenAccount(string id, string name, string pwd, double money, string type, double creditLimit)
	{
		try
        {
			Account account;
			if (type == "credit")
            {
				account = new CreditAccount(id, name, pwd, money, creditLimit);
			}
			else
            {
				account = new Account(id, name, pwd, money);
			}
			accounts.Add(account);
			return account;
		}
        catch
        {
			return null;
        }
	}

	public bool CloseAccount(Account account)
	{
		int idx = accounts.IndexOf(account);
		if (idx < 0)
		{
			return false;
		}
		accounts.Remove(account);
		return true;
	}

	public Account FindAccount(string id, string pwd)
	{
		foreach (Account account in accounts)
		{
			if (account.IsMatch(id, pwd))
			{
				return account;
			}
		}
		return null;
	}

}
