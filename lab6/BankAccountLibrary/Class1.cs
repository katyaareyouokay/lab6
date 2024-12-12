using System;

namespace BankAccountLibrary
{
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        private float _balance;
        // Конструктор класса.
        public BankAccount(string accountNumber, float balance = 0.0f)
        {
            if (balance < 0)
            {
                throw new ArgumentException("Начальный баланс не может быть отрицательным.");
            }

            AccountNumber = accountNumber;
            _balance = balance;
        }
        // Метод для пополнения баланса.
        public void Deposit(float amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма пополнения должна быть положительной.");
            }

            _balance += amount;
        }
        //  Метод для снятия денег со счёта.
        public void Withdraw(float amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть положительной.");
            }

            if (amount > _balance)
            {
                throw new InvalidOperationException("Недостаточно средств");
            }

            _balance -= amount;
        }
        // Метод для получения текущего баланса.
        public float GetBalance()
        {
            return _balance;
        }
    }
}
