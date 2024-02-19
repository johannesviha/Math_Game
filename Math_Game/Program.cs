StartGame.Main();
Console.ReadKey();

public class StartGame
{
    private static List pastCalculationsList;
    static StartGame()
    {
        pastCalculationsList = new List();
    }
    public static void Main()
    {
        PromptChoice promptChoice = new PromptChoice(pastCalculationsList);
        bool isTrue = false;

        Console.WriteLine("Welcome to the math game.\n");

        while (!isTrue)
        {
            Console.WriteLine("Would you like to continue?");
            Console.WriteLine("Y for yes. N for no. V for past calculations.");
            string userInput = Console.ReadLine();

            Operations operations = new Operations(pastCalculationsList);

            switch (userInput.ToLower())
            {
                case "y":
                    isTrue = promptChoice.PromptUser();
                    break;
                case "n":
                    Console.WriteLine("Press any key to exit.");
                    string userChoice = Console.ReadLine();
                    Environment.Exit(0);
                    break;
                case "v":
                    pastCalculationsList.ViewList();
                    break;
                default:
                    Console.WriteLine("That's not a valid choice. Try again.");
                    continue;
            }

        }
    }
}

public class PromptChoice
{
    private List pastCalculationsList = new List();

    public PromptChoice(List list)
    {
        pastCalculationsList = list;
    }
    public bool PromptUser()
    {
        int firstValue = 0;
        int secondValue = 0;
        bool firstLoop = false;
        bool secondLoop = false;
        bool thirdLoop = false;

        while (!firstLoop)
        {

            Console.WriteLine("Enter a number: ");
            string userInput1 = Console.ReadLine();

            bool validateFirstNumber = int.TryParse(userInput1, out firstValue);

            if (validateFirstNumber == false)
            {
                Console.WriteLine("That's not a valid number. Try again.\n");
                continue;
            }
            else
            {
                firstLoop = true;
            }
        }

        while (!secondLoop)
        {
            Console.WriteLine("Enter another number: ");
            string userInput2 = Console.ReadLine();
            bool validateSecondNumber = int.TryParse(userInput2, out secondValue);

            if (validateSecondNumber == false)
            {
                Console.WriteLine("That's not a valid number. Try again.\n");
                continue;
            }
            else
            {
                secondLoop = true;
            }
        }



        while (!thirdLoop)
        {
            Console.WriteLine("Which calculator operation would you like to use?");

            Console.WriteLine("[A]dd");
            Console.WriteLine("[S]ubstract");
            Console.WriteLine("[M]ultiply");
            Console.WriteLine("[D]ivide");
            Console.WriteLine("[V]iew past calculations");
            Console.WriteLine("[E]xit");

            string userChoice = Console.ReadLine().ToLower();

            Operations operations = new Operations(pastCalculationsList);
            switch (userChoice)
            {
                case "a":
                    thirdLoop = true;
                    operations.Add(firstValue, secondValue);
                    break;
                case "s":
                    thirdLoop = true;
                    operations.Substract(firstValue, secondValue);
                    break;
                case "m":
                    thirdLoop = true;
                    operations.Multiply(firstValue, secondValue);
                    break;
                case "d":
                    thirdLoop = true;
                    operations.Divide(firstValue, secondValue);
                    break;
                case "v":
                    thirdLoop = true;
                    pastCalculationsList.ViewList();
                    break;
                case "e":
                    thirdLoop = true;
                    Console.WriteLine("Press any key to exit.");
                    return true;
                default:
                    Console.WriteLine("That's not a valid choice. Please try again.");
                    continue;
            }
        }
        return false;

    }

}

public class Operations
{
    private List _pastCalculationsList = new List();

    public Operations(List pastCalculationsList)
    {
        _pastCalculationsList = pastCalculationsList;
    }
    public void Add(int value1, int value2)
    {
        Console.WriteLine($"The sum of {value1} + {value2} = {value1 + value2}");
        _pastCalculationsList.AddToList($"The sum of {value1} + {value2} = {value1 + value2}");
    }

    public void Substract(int value1, int value2)
    {
        Console.WriteLine($"The difference of {value1} - {value2} = {value1 - value2}");
        _pastCalculationsList.AddToList($"The difference of {value1} - {value2} = {value1 - value2}");
    }

    public void Multiply(int value1, int value2)
    {
        Console.WriteLine($"The product of {value1} * {value2} = {value1 * value2}");
        _pastCalculationsList.AddToList($"The product of {value1} * {value2} = {value1 * value2}");
    }

    public void Divide(int value1, int value2)
    {
        if (value2 != 0 && value2 <= 100 && value1 % value2 == 0)
        {
            Console.WriteLine($"The quotient of {value1} / {value2} = {value1 / value2}");
            _pastCalculationsList.AddToList($"The quotient of {value1} / {value2} = {value1 / value2}");
        }
        else
        {
            Console.WriteLine("Invalid division. Ensure divisor is not zero, divisor is less than or equal to 100, and the result is an integer.");
        }

    }
}

public class List
{
    private List<string> pastCalculationsList = new List<string>();

    public void AddToList(string result)
    {
        pastCalculationsList.Add(result);
    }

    public void ViewList()
    {
        if (!pastCalculationsList.Any())
        {
            Console.WriteLine("There are no past calculations. Try to use an operation.");
        }
        else
        {
            Console.WriteLine("Here are your past calculations:");
            foreach (string item in pastCalculationsList)
            {
                Console.WriteLine($"{item}\n");
            }
        }


    }
}

