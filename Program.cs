using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ITransaction
{
    void PerformTransaction();
}


public class Transaction
{
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    public Transaction(decimal amount, DateTime transactionDate)
    {
        Amount = amount;
        TransactionDate = transactionDate;
    }
}

public class FinancialTransaction : Transaction, ITransaction
{
    public FinancialTransaction(decimal amount, DateTime transactionDate) 
        : base(amount, transactionDate)
    {

    }

    public void PerformTransaction()
    {
        Console.WriteLine($"Performing transaction of {Amount} at {TransactionDate}");
    }
}

public class TransactionException : Exception
{
    public TransactionException(string message) : base(message)
    {
        Console.WriteLine(message);
    }
}

public class TransactionProcessor
{
    public event EventHandler<string> TransactionCompleted;

    public void ProcessTransaction(ITransaction transaction)
    {
        try
        {
            transaction.PerformTransaction();
            TransactionCompleted?.Invoke(this, "Transaction successful.");
        }
        catch (Exception ex)
        {
            TransactionCompleted?.Invoke(this, $"Transaction failed: {ex.Message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FinancialTransaction transaction = new FinancialTransaction(100, DateTime.Now);
        TransactionProcessor processor = new TransactionProcessor();
        processor.TransactionCompleted += (sender, message) => Console.WriteLine(message);
        processor.ProcessTransaction(transaction);
    }
}
