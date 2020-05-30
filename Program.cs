using System;

namespace calculator
{
    public static class MathCalculator
    {
        public static void MathCalculate()
        {
            var firstDigit = double.MaxValue;
            var secondDigit = double.MaxValue;
            char operation = 'n';

            Console.WriteLine("Math calculator\n");
            Console.WriteLine("---------------\n");

            try
            {
                Console.WriteLine("Enter your equation:");
                var strEquation = Console.ReadLine().Split(" ");
                foreach (var item in strEquation)
                
                    if (!int.TryParse(item, out int parsedValue))
                    {
                        operation = item.ToCharArray()[0];
                    }

                    else if (firstDigit == double.MaxValue)
                    {
                        firstDigit = parsedValue;
                    }

                    else if (secondDigit == double.MaxValue)
                    {
                        secondDigit = parsedValue;

                        if (firstDigit != double.MaxValue && secondDigit != double.MaxValue && operation != 'n')
                        {
                            firstDigit = CompareOperations(firstDigit, secondDigit, operation);
                            secondDigit = double.MaxValue;
                            operation = 'n';
                        }
                    }
                }


            catch (FormatException e)
            {
                Console.WriteLine("The provided value isn\'t in a valid format. Details: ", e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("The provided value isn\'t in the range of minimal and maximal values. Details: ", e.Message);
            }

            Console.WriteLine($"The result is: {firstDigit}");

        }

        private static double CompareOperations(double firstNumber, double secondNumber, char operation)
        {
            switch (operation)
            {
                case '*':
                    return firstNumber * secondNumber;
                case '/':
                    return firstNumber / secondNumber;
                case '+':
                    return firstNumber + secondNumber;
                case '-':
                    return firstNumber - secondNumber;
                default:
                    return 0;
            }
        }
    }

    public static class BMICalculator
    {
        public static void BMICalculate()
        {
            double mass = 0;
            double height = 0;
            double result;

            Console.WriteLine("BMI calculator\n");
            Console.WriteLine("---------------\n");

            try
            {
                Console.WriteLine("Enter a mass:");
                mass = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter a height (in centimeters):");
                height = Convert.ToDouble(Console.ReadLine()) / 100;
            }
            catch (FormatException e)
            {
                Console.WriteLine("The provided value isn\'t in a valid format. Details: ", e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("The provided value isn\'t in the range of minimal and maximal values. Details: ", e.Message);
            }

            result = (double)mass / Math.Pow(height, 2);

            Console.WriteLine($"Your BMI is: {result}");

        }
    }

    public static class DistanceConverter
    {
        public static void DistanceConvert()
        {

            Console.WriteLine("Distance converter\n");
            Console.WriteLine("---------------\n\n");

            Console.WriteLine("You want to convert a distance to miles or kilometers?");
            Console.WriteLine("1. To miles\n 2. To kilometers");

            bool IsChosenOptionValid = false;

            while (!IsChosenOptionValid)
            {

                switch (Console.ReadKey(true).KeyChar.ToString())
                {

                    case "1":
                        ConvertToMiles();
                        IsChosenOptionValid = true;
                        break;

                    case "2":
                        ConvertToKilometers();
                        IsChosenOptionValid = true;
                        break;

                    default:
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        break;

                }
            }

            return;
        }

        private static void ConvertToMiles()
        {
            double kilometre = 0;
            double toMilesResult;

            try
            {
                Console.WriteLine("Enter a distance in kilometers:");
                kilometre = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("The provided value isn\'t in a valid format. Details: ", e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("The provided value isn\'t in the range of minimal and maximal values. Details: ", e.Message);
            }

            toMilesResult = kilometre * (float)0.62;

            if (kilometre == 1)
            {
                Console.WriteLine($"{kilometre} kilometre equals to {toMilesResult} miles.");
            }
            else
            {
                Console.WriteLine($"{kilometre} kilometers equals to {toMilesResult} miles.");
            }

        }

        private static void ConvertToKilometers()
        {
            double mile = 0;
            double toKilometersResult;

            try
            {
                Console.WriteLine("Enter a distance in miles:");
                mile = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("The provided value isn\'t in a valid format. Details: ", e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("The provided value isn\'t in the range of minimal and maximal values. Details: ", e.Message);
            }

            toKilometersResult = mile * (float)1.60;

            if (mile == 1)
            {
                Console.WriteLine($"{mile} mile equals to {toKilometersResult} kilometers.");
            }
            else
            {
                Console.WriteLine($"{mile} miles equals to {toKilometersResult} kilometers.");
            }

        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console calculator in C#");
            Console.WriteLine("------------------------\n\n");

            while (!endApp)
            {

                Console.WriteLine("Which calculator you want to use?");
                Console.WriteLine("1. Math calculator\n 2. BMI calculator\n 3. Distance converter\n 4. Quit");

                bool IsValidOption = false;

                while (!IsValidOption)
                {
                    var option = Console.ReadKey(true).KeyChar.ToString();
                    switch (option)
                    {

                        case "1":
                            MathCalculator.MathCalculate();
                            IsValidOption = true;
                            break;

                        case "2":
                            BMICalculator.BMICalculate();
                            IsValidOption = true;
                            break;

                        case "3":
                            DistanceConverter.DistanceConvert();
                            IsValidOption = true;
                            break;
                        case "4":
                            IsValidOption = true;
                            endApp = true;
                            break;

                        default:
                            Console.WriteLine("This is not valid input. Please enter an integer value: ");
                            break;
                    }


                }

            }

            return;
        }
    }
}