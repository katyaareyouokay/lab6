using System;
using BankAccountLibrary;

[TestFixture]
public class BankAccountTests
{
    // �������� ������� � ���������� ��������� ��������.
    [Test]
    public void CreateAccount_WithValidInitialBalance()
    {
        string accountNumber = "969574635";
        float initialBalance = 100.0f;

        var account = new BankAccount(accountNumber, initialBalance);

        Assert.That(account.GetBalance(), Is.EqualTo(initialBalance));
    }

    // �������� ������� � ������������ ��������� ��������.
    [Test]
    public void CreateAccount_WithNegativeInitialBalance()
    {
        string accountNumber = "123456789";
        float initialBalance = -100.0f;

        Assert.Throws<ArgumentException>(() => new BankAccount(accountNumber, initialBalance));
    }

    // �������� ���������� �������.
    [Test]
    public void Deposit_WithPositiveAmount()
    {
        var account = new BankAccount("44874323", 100.0f);
        float depositAmount = 50.0f;

        account.Deposit(depositAmount);

        Assert.That(account.GetBalance(), Is.EqualTo(150.0f));
    }

    // ������� ��������� ������������ ����� (0 ��� ������������� ��������)
    [Test]
    public void Deposit_WithNonPositiveAmount()
    {
        var account = new BankAccount("46398323", 100.0f);
        float depositAmount = 0.0f;

        Assert.Throws<ArgumentException>(() => account.Deposit(depositAmount));
    }

    // �������� ������, ���� ����� �� ��������� ������.
    [Test]
    public void Withdraw_WithValidAmount()
    {
        var account = new BankAccount("836442536", 100.0f);
        float withdrawAmount = 50.0f;

        account.Withdraw(withdrawAmount);

        Assert.That(account.GetBalance(), Is.EqualTo(50.0f));
    }

    // ������ ��� ������� ����� ����� ������ �������� �������.
    [Test]
    public void Withdraw_WithAmountGreaterThanBalance()
    {
        var account = new BankAccount("969574635", 100.0f);
        float withdrawAmount = 150.0f;

        Assert.Throws<InvalidOperationException>(() => account.Withdraw(withdrawAmount));
    }

    // ������ ��� ������� ����� ������������ ����� (0 ��� ������������� ��������).
    [Test]
    public void Withdraw_WithNonPositiveAmount()
    {
        var account = new BankAccount("123456789", 100.0f);
        float withdrawAmount = 0.0f;

        Assert.Throws<ArgumentException>(() => account.Withdraw(withdrawAmount));
    }

    // �������� �������� ������� ����� ��������.
    [Test]
    public void GetBalance_AfterOperations()
    {
        var account = new BankAccount("123456789", 100.0f);

        account.Deposit(50.0f);
        account.Withdraw(30.0f);

        Assert.That(account.GetBalance(), Is.EqualTo(120.0f));
    }

}
