using System.Net.Cache;
using System.Runtime.InteropServices;

namespace ConsoleApp1;

    internal class Program
    {
        static void Main()
        {
            Person[] people = new Person[3];
            people[0] = new Person { Name = "Ali", Age = 20 };
            people[1] = new Person { Name = "Sara", Age = 25 };
            people[2]=new Person {Name="Omar",Age = 30};

            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }   


            ////////////////////////////////////


            Console.WriteLine("Enter the coordinates of the first point (X1, Y1).");

            Console.Write("Enter X1: ");
            double x1 = double.Parse(Console.ReadLine());

            Console.Write("Enter Y1: ");
            double y1 = double.Parse(Console.ReadLine());


            Console.WriteLine("Enter the coordinates of the second point (X2, Y2).");
            Console.Write("Enter X2: ");
            double x2 = double.Parse(Console.ReadLine());

            Console.Write("Enter Y2: ");
            double y2 = double.Parse(Console.ReadLine());


            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) +
                             Math.Pow(y2 - y1, 2));
            Console.WriteLine($"Distance between points={distance}");


            ////////////////////////////////////
            
            Console.WriteLine(" Enter name and age of 3 persons.");
            Person[] people2 = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                string[] input = Console.ReadLine().Split(); 
                string name = input[0];                    
                int age = int.Parse(input[1]);            

                people2[i] = new Person { Name = name, Age = age };
            
            }
            Person oldest = people2[0]; 
                for (int i = 1; i < people2.Length; i++)
                {
                       if (people2[i].Age > oldest.Age)
                          {
                              oldest = people2[i];
                          }
                }
        
           Console.WriteLine($"Oldest person: {oldest.Name}, Age: {oldest.Age}");
        ////////////////////////////////
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 10;
            rectangle.Height = 5;
             rectangle.DisplayInfo();
             rectangle.Width = -3;
             rectangle.Height = 8;
             rectangle.DisplayInfo();
        /////////////////////////////////////
        BankAccount account = new BankAccount("A123", 500);
        account[0] = 1000;
        account[1] = 2000;
        account[2] = 3000;
        Console.WriteLine(account[0]);
        ////////////////////////////
        Student s = new Student { Name = "Sara", Age = 20 };
        s[0] = 90;
        s[1] = 85;
        Console.WriteLine(s[0]);
        ///////////////
        Employee emp = new Employee();
        emp[0] = "C#";
        emp[1] = "SQL";
        emp[2] = "Java";
        Console.WriteLine(emp[1]);
        /////////////////
        Car car = new Car();
        car[2020] = 500;
        car[2021] = 600;
        Console.WriteLine($"Maintenance in 2020: {car[2020]}");
       ////////////////
       



    }
}


    public struct Person { 
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

public struct Rectangle
{
    private double _width;
    private double _height;
    public double Width
    {
        get => _width;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Width cannot be negative");
                return;
            }
            _width = value;
        }
    }
    public double Height
    {
        get => _height;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Height cannot be negative");
                return;
            }
            _height = value;
        }
    }
    public double Area => _width * _height;
    public void DisplayInfo()
    {
        Console.WriteLine($"Width: {_width}, Height: {_height}, Area: {Area}");
    }
}
    class BankAccount
    {
        public string AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount}. New Balance = {Balance}");
            }
            else
            {
                Console.WriteLine("Error: Deposit amount must be positive.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance && amount > 0)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}. New Balance = {Balance}");
            }
            else
            {
                Console.WriteLine("Error: Invalid withdrawal amount or insufficient funds.");
            }
        }

        public bool HasSufficientFunds(double amount)
        {
            return Balance >= amount;
        }

        public void TransferTo(BankAccount target, double amount)
        {
            if (HasSufficientFunds(amount))
            {
                this.Balance -= amount;
                target.Balance += amount;
                Console.WriteLine($"Transferred {amount} from {AccountNumber} to {target.AccountNumber}");
            }
            else
            {
                Console.WriteLine("Error: Not enough balance to transfer.");
            }
        }

        public void DisplayAccount()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");
        }
        private double[] currencyBalances = new double[3];
        public double this[int index]
        {
            get { return currencyBalances[index]; }
            set { currencyBalances[index] = value; }

        }
    public BankAccount(string accountNumber, double initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }


}
class Student
{
    public string Name { get; init; }
    private int _age;
    public int Age
    {
        get { return _age; }
        init
        {
            if (value < 0)
                return;
            _age = value;
        }

    }
    public bool IsAdult()
    {
        if (_age < 18)
            return false;
        else
            return true;
    }
    public double YearsUntilGraduation(int graduationAge = 22)
    {
        double YearsLeftUntilGraduation = graduationAge - _age;
        return YearsLeftUntilGraduation;
    }
    public void DisplayStudent()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
        Console.Write("Grades: ");
        for (int i = 0; i < grades.Length; i++)
        {
            Console.Write(grades[i] + " ");
        }
        
    }
    private double[] grades = new double[5];
    public double this[int index] {
        get { return grades[index]; } set { grades[index] = value; }
    }
    
}
class Employee
{
    private double _salary;
    public double Salary
    {
        get { return _salary; }
        set
        {
            if (value < 0)
                return;
            _salary = value;

        }
    }
    public void IncreaseSalary(double amount)
    {
        if (amount > 0)
            _salary += amount;
        else
            return;
    }
    public double AnnualSalary()
    {
        return _salary*12;
    }
    public double ApplyBonus(double percentage)
    {
        double bonusAmount = _salary * (percentage / 100);
        double newSalary = _salary + bonusAmount;
        return newSalary;
    }
    
    public void DisplayEmployee()
    {
        Console.WriteLine($"Monthly Salary: {_salary}");
        Console.WriteLine($"Annual Salary: {AnnualSalary()}");
    }
    private string[] emp=new string [5] ;
    public string this[int index] { 
        get{ return emp[index]; } set { emp[index] = value; }
    }

}
class Car
{
    public string Brand { get; set; } = "Toyota";
    public int Year { get; set; }
    public void UpdateYear(int year)
    {
        if (year >= 1886)
            Year = year;
        else
            return;
    }
    public int CarAge()
    {
        return DateTime.Now.Year - Year;
    }
    public bool IsClassic()
    {
        if (CarAge() > 25)
            return true;
        else return false;
    }
    public void DisplayCar()
    {
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Age: {CarAge()} years");
        Console.WriteLine($"Classic: {IsClassic()}");
    }
    private int[] years = new int[10];
    private double[] maintenance = new double[10];
    private int count = 0;
    public double this[int year]
    {
        get
        {

            for (int i = 0; i < count; i++)
            {
                if (years[i] == year)
                    return maintenance[i];
            }
            return 0;
        }

        set
        {
            for (int i = 0; i < count; i++)
            {
                if (years[i] == year)
                {
                    maintenance[i] = value;
                    return;
                }
            }

            years[count] = year;
            maintenance[count] = value;
            count++;
        }

    }
}
class LibraryBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }

}



