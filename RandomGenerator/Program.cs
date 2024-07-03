using RandomGenerator.models;
using System;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;
internal class Program
{
    static void Main(string[] args)
    {
        int userChoiceValue = 0;
        bool isTrue = true;

        do
        {
            try
            {
                Console.WriteLine("Which service do you want to use? ");
                Console.WriteLine("1 => Users Generator");
                Console.WriteLine("2 => Full Name Generator");
                Console.WriteLine("3 => Email Address Generator");
                Console.WriteLine("4 => Integer Range Generator");
                Console.Write("Your choice: ");

                int userChoice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many random do you want it to generate?");
                Console.Write("Enter the value: ");
                userChoiceValue = Convert.ToInt32(Console.ReadLine());

                switch(userChoice)
                {
                    case 1: GenerateUser(userChoiceValue); break;
                    case 2: GenerateFullName(userChoiceValue); break;
                    case 3: GenerateEmail(userChoiceValue); break;
                    case 4: GenerateInteger(userChoiceValue); break;
                        default: Console.WriteLine("Enter enter number between 1 and 4");break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Do you want to continue? (yes / no)");
            string checkWhile = Console.ReadLine().ToLower();
            isTrue = checkWhile is "yes" or "y";

        } while (isTrue);

        static void GenerateUser(int count)
        {
            Filler<User> userFiller = new Filler<User>();
            List<User> users = new List<User>();

            userFiller.Setup()
            .OnProperty(u => u.FirstName).Use(new RealNames(NameStyle.FirstName))
            .OnProperty(u => u.LastName).Use(new RealNames(NameStyle.LastName))
            .OnProperty(u => u.Email).Use(new EmailAddresses("example.com"));

            users = userFiller.Create(count).ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"\t\tIsm: {user.FirstName}, Familiya: {user.LastName}, Email: {user.Email}");
            }
        }
        static void GenerateFullName(int count)
        {
            RealNames realNames = new RealNames();

            Console.WriteLine("Full Name is: ");
            for (int i = 0; i < count; i++)
            {
                //string fullName = realNames.GetValue();
                Console.WriteLine($"\t\t{realNames.GetValue()}");
            }
        }
        static void GenerateEmail(int count)
        {
            EmailAddresses emailAddresses = new EmailAddresses();

            Console.WriteLine("Email Address is: ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\t\t{emailAddresses.GetValue()}");
            }
        }
        static void GenerateInteger(int count)
        {
            Console.Write("Enter starting value =>");
            int startValue = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter ending value => ");
            int endedValue = Convert.ToInt32(Console.ReadLine());

            IntRange integerRange = new IntRange(startValue,endedValue);
            Console.WriteLine("Numbers is: ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\t\t{integerRange.GetValue()}");
            }
        }
    }
}
