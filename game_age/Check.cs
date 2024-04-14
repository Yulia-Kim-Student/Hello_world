using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;
using static System.Collections.Specialized.BitVector32;

//ДОБАВИТЬ КАЛЬКУЛЯТОР И ПРОСТЫЕ ЧИСЛА
namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            Console.Write("What's you name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}. ");

            while (true)
            {
                Console.WriteLine("Do you want to play a game? Press Y - yes, N - no");

                char wanted = Console.ReadKey(true).KeyChar;

                if (wanted == 'y' || wanted == 'Y')
                {
                    while (true)
                    {
                        Console.WriteLine("We can play the following, click on:\n" +
                            "1) Addition\n" +
                            "2) Subtraction\n" +
                            "3) Multiplication\n" +
                            "4) Division\n" +
                            "5) Definition of a Prime Number\n" +
                            "6) Сalculator\n" +
                            "7) Months or\n" +
                            "8) Prime numbers calculator");
                        char play_chose = Console.ReadKey(true).KeyChar;
                        switch (play_chose)
                        {
                            case '1':
                                Console.WriteLine("Game 1");
                                Addition();
                                break;
                            case '2':
                                Console.WriteLine("Game 2");
                                Subtraction();
                                break;
                            case '3':
                                Console.WriteLine("Game 3");
                                Multiplication();
                                break;
                            case '4':
                                Console.WriteLine("Game 4");
                                Division();
                                break;
                            case '5':
                                Console.WriteLine("Game 5");
                                IsPrime();
                                break;
                            case '6':
                                Console.WriteLine("Game 6");
                                Сalculator();
                                break;
                            case '7':
                                Console.WriteLine("Game 7");
                                GameAge(name);
                                break;
                            case '8':
                                Console.WriteLine("Game 8");
                                SimpCalc();
                                break;
                            default:
                                Console.WriteLine("Invalid button. Click on 1,2 or 3.. ets");
                                break;
                        }
                    }
                }
                else if (wanted == 'n' || wanted == 'N')
                {
                    Console.WriteLine("It is sad.");
                    break;
                }
                else
                {
                    Console.WriteLine("Click on the correct button..");
                    continue;
                }
            }
        }
        static void TheEnd()
        {
            Console.WriteLine("Press something to return to the menu.");
            Console.ReadKey();
            Console.Clear();
        }
        static void RetCalculator(float x, float y)
        {
            Console.WriteLine("Choose operation. Input '+','-','*' or '/'.");
            char operation = Console.ReadKey(true).KeyChar;
            while (!(operation == '+' || operation == '-' || operation == '*' || operation == '/'))
            {
                Console.WriteLine("Wrong button. Input '+','-','*' or '/'.");
                operation = Console.ReadKey(true).KeyChar;
            }
            float result = 0;
            switch (operation)
            {
                case '+':
                    result =  x + y;
                    break;
                case '-':
                    result = x - y;
                    break;
                case '*':
                    result = x * y;
                    break;
                case '/':
                    if (y == 0)
                    {
                        Console.WriteLine("You can't divide by zero.");
                    }
                    result = x / y;
                    break;
            }
            Console.WriteLine($"{x} {operation} {y} = {result}");
        }
        static float TakeFloat()
        {
            float number = 0;
            while (!float.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("It's not a number ");
            }
            return number;
        }
        static bool PrimeNum(ulong number)  // Проверка на простое
        {
            if (number == 1)
            {
                return false;
            }
            if (number % 2 == 0)
            {
                return number == 2;
            }
            if (number % 3 == 0)
            {
                return number == 3;
            }
            for (ulong i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void Addition() 
        {
            Console.WriteLine("Write first number: ");
            float el_number_1 = TakeFloat();
            Console.WriteLine("Write second number: ");
            float el_number_2 = TakeFloat();

            //Console.WriteLine("What do we do with these numbers: 1) add 2) subtract 3) multiply 4) divide");
            //char calculator_action = Console.ReadKey(true).KeyChar;

            float sum = el_number_1 + el_number_2;
            Console.WriteLine($"The sum of the elements was: {sum}.");
            TheEnd();
        }
        static void GameAge(string name)
        {
            bool again = true;
            while (again)
            {
                int age;
                Console.WriteLine($"Hello {name}!");
                Console.Write("How old are you? ");
                while (!int.TryParse(Console.ReadLine(), out age) || age < 5 || age > 122)
                {
                    Console.WriteLine("Real age. Please ");
                }
                Console.Write("The month of birth number? ");
                int num_month;
                while (!int.TryParse(Console.ReadLine(), out num_month) || num_month < 1 || num_month > 12)
                {
                    Console.WriteLine("Please enter a valid month number (between 1 and 12): ");
                }
                string season = "";
                switch (num_month)
                {
                    case 1:
                    case 2:
                    case 12:
                        season = "Winter.";
                        break;
                    case 3:
                    case 4:
                    case 5:
                        season = "Spring.";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        season = "Summer.";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        season = "Autumn.";
                        break;
                }
                DateTime today = DateTime.Now;

                int year = today.Year;
                int month = today.Month;
                int day = today.Day;

                if (month < num_month)
                {
                    Console.WriteLine($"It mean's you were born in the {season} of {year - age}");
                }
                else if (month > num_month)
                {
                    Console.WriteLine($"It mean's you were born in the {season} of {year - age + 1}");
                }
                else
                {
                    Console.WriteLine($"Is your birth date less than {day}?\nPress 'y' or 'n'.");
                    char less_day = Console.ReadKey(true).KeyChar;
                    while (!(less_day == 'y' || less_day == 'n'))
                    {
                        Console.WriteLine("Wrong button. Input 'y' or 'n'");
                        less_day = Console.ReadKey(true).KeyChar;
                    }
                    switch (less_day)
                    {
                        case 'y':
                            Console.WriteLine($"It mean's you were born in the {season} of {year - age + 1}");
                            break;
                        case 'n':
                            Console.WriteLine($"It mean's you were born in the {season} of {year - age}.\nIf it's today, Happy Birthday!");
                            break;
                    }
                }
                Console.WriteLine("Is it all right?\nPress 'y' if i'm right.");
                char answer = Console.ReadKey(true).KeyChar;
                if (answer == 'y')
                {
                    again = false;
                    Console.WriteLine("Yay :3");
                    TheEnd();
                }
                else
                {
                    Console.WriteLine("Damn. We're gonna have to do it again.");
                }
            }
        }
        static void Subtraction()
        {
            Console.WriteLine("Write first number: ");
            float el_number_1 = TakeFloat();
            Console.WriteLine("Write second number: ");
            float el_number_2 = TakeFloat();

            float difference = el_number_1 - el_number_2;
            Console.WriteLine($"The difference of the elements was: {difference}.");
            TheEnd();
        }
        static void Multiplication()
        {
            Console.WriteLine("Write first number: ");
            float el_number_1 = TakeFloat();
            Console.WriteLine("Write second number: ");
            float el_number_2 = TakeFloat();

            float quotient = el_number_1 * el_number_2;
            Console.WriteLine($"The quotient of the elements was: {quotient}.");
            TheEnd();
        }
        static void Division() 
        {
            Console.WriteLine("Write first number: ");
            float el_number_1 = TakeFloat();
            Console.WriteLine("Write second number: ");
            float el_number_2 = TakeFloat();

            float product = el_number_1 / el_number_2;
            Console.WriteLine($"The product of the elements was: {product}.");
            TheEnd();
        }
        static void IsPrime()
        {
            Console.WriteLine("Write the number: ");
            ulong simple_number;
            while (!ulong.TryParse(Console.ReadLine(), out simple_number) || simple_number < 1)
            {
                Console.WriteLine("Incorrect data. Try again");
            }
            if (PrimeNum(simple_number))
            {
                Console.WriteLine("Simple.");
                TheEnd();
            }
            else
            {
                Console.WriteLine("Not a simple.");
                TheEnd();
            }
        }
        static void Сalculator()
        {
            Console.WriteLine("Write first number: ");
            float el_number_1 = TakeFloat();
            Console.WriteLine("Write second number: ");
            float el_number_2 = TakeFloat();
            RetCalculator(el_number_2, el_number_1);
            TheEnd();
        }
        static void SimpCalc()
        {
            Console.WriteLine("Give me the first prime number: ");
            ulong first;
            while (!ulong.TryParse(Console.ReadLine(), out first) || first < 1 || !PrimeNum(first))
            {
                Console.WriteLine("That's not what I need. Try again.");
            }
            float first_for_calc = first;
            Console.WriteLine("Give me the second prime number: ");
            ulong second;
            while (!ulong.TryParse(Console.ReadLine(), out second) || second < 1 || !PrimeNum(second))
            {
                Console.WriteLine("That's not what I need. Try again.");
            }
            float second_for_calc = second;
            RetCalculator(first_for_calc, second_for_calc);
            TheEnd();
        }       
    }
}