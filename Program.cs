using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Collections;

interface IBook
{
    void GetBook();
}

class FictionBook : IBook
{
    public delegate void CheckOutHandler(object source, EventArgs? args);  // delegate
    public event CheckOutHandler? CheckedOut;
    public string? BookName { get; set; }
    public string? Genre { get => "Fiction"; }
    public double DeweyDecimal { get; set; }
    public int Availability { get; set; }


    public void CheckingOut()
    {
        Console.WriteLine("Preparing book to check out "+ BookName +", please wait..");
        if (Availability > 0)
        {
            Availability--;
            OnCheckedOut();
        }
        else
        {
            Console.WriteLine(BookName + " is not available.");
        }
    }

    protected virtual void OnCheckedOut()
    {
        CheckedOut?.Invoke(this, null);
        Console.WriteLine(BookName + "has been checked out");

    }

    public void GetBook()
    {
        Console.WriteLine("This is the book: " + BookName +
            ", located at decimal: " + DeweyDecimal + ", and there are "
            + Availability + " of these books available at this time.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        FictionBook BookList = new FictionBook();
        FictionBook book1 = new FictionBook();
        book1.BookName = "Frankenstein";
        book1.DeweyDecimal = 023.7;
        book1.Availability = 5;

        FictionBook book2 = new FictionBook();
        book2.BookName = "Great Gatsby";
        book2.DeweyDecimal = 524.7;
        book2.Availability = 0;

        FictionBook book3 = new FictionBook();
        book3.BookName = "Pride and Prejudice";
        book3.DeweyDecimal = 223.5;
        book3.Availability = 2;

        book2.CheckingOut();

        book3.GetBook();
        book3.CheckingOut();
        book3.GetBook();

    }
}