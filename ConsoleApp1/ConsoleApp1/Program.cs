using System;

// Abstract class Worker
public abstract class Worker : IDisposable
{
    // Fields of Worker class
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }

    protected Random random = new Random();

    // Default constructor for Worker
    public Worker()
    {
        Name = "Bob";
        Age = random.Next(18, 61);
        Salary = random.Next(5000, 15000);
        Console.WriteLine("Default worker constructor was called!");
    }

    // Parameterized constructor for Worker
    public Worker(string name, int age, decimal salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
        Console.WriteLine("Parameterized worker constructor was called!");
    }

    // Virtual method to display information about Worker object
    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Salary: {Salary}");
    }

    // Abstract method that must be implemented in derived classes
    public abstract void DoWork();

    // Implementation of IDisposable interface
    public void Dispose()
    {
        Console.WriteLine("Dispose method of worker class was called!");
    }
}

// Derived class Personnel
public class Personnel : Worker
{
    public int Experience { get; set; }

    // Default constructor for Personnel
    public Personnel() : base()
    {
        Name = "Leri";
        Experience = random.Next(0, Age - 18 + 1);
        Console.WriteLine("Default personnel constructor was called!");
    }

    // Parameterized constructor for Personnel
    public Personnel(string name, int age, decimal salary, int experience) : base(name, age, salary)
    {
        Experience = experience;
        Console.WriteLine("Parameterized personnel constructor was called!");
    }

    // Override method to display information about Personnel object
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Experience: {Experience}");
    }

    // Implementation of abstract method DoWork
    public override void DoWork()
    {
        Console.WriteLine("Doing personnel work...");
    }
}

// Derived class Engineer
public class Engineer : Personnel
{
    public string Specialization { get; set; }

    // Default constructor for Engineer
    public Engineer() : base()
    {
        Name = "Lina";
        Specialization = "Mechanical Engineer";
        Console.WriteLine("Default engineer constructor was called!");
    }

    // Parameterized constructor for Engineer
    public Engineer(string name, int age, decimal salary, int experience, string specialization) : base(name, age, salary, experience)
    {
        Specialization = specialization;
        Console.WriteLine("Parameterized engineer constructor was called!");
    }

    // Override method to display information about Engineer object
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Specialization: {Specialization}");
    }

    // Implementation of abstract method DoWork
    public override void DoWork()
    {
        Console.WriteLine("Doing engineering work...");
    }
}

class Program
{
    static void Main()
    {
        // Creating objects of different classes and calling the Show method
        /*Worker worker = new Worker();
        worker.Show();
        Console.WriteLine();*/

        Personnel personnel = new Personnel();
        personnel.Show();
        Console.WriteLine();

        Engineer engineer = new Engineer();
        engineer.Show();
        Console.WriteLine();

        // Using polymorphism via the base class Worker
        Worker[] workers = new Worker[]
        {
            new Personnel("John", 30, 8000, 5),
            new Engineer("Kate", 35, 10000, 10, "Civil Engineer")
        };

        foreach (var w in workers)
        {
            w.Show();
            w.DoWork();
            Console.WriteLine();
        }
    }
}
