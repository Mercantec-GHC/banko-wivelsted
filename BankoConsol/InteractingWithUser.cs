
public static class InteractingWithUser
{
	private static int _maxPlates = 6;
	private static List<List<int[]>> _userPlates = new(); 
	public static List<List<int[]>> UserPlates => _userPlates;
	private static List<int> _userPlateIds = new();

	public static void ShowGreeting()
	{
		Console.WriteLine("*\t*\t*\t*\t*\t*\t*\t*\t*\t*\t*\t*\n");
		Console.WriteLine("*\t\t\t\tWelcome to a Bingo Game!\t\t\t\t* ");
		Console.WriteLine("\n*\t*\t*\t*\t*\t*\t*\t*\t*\t*\t*\t*");
	}

	public static void GetUserInputAndGenerateAssignedPlates()
	{
		Console.Write("Please enter your name: ");
		string userName = Console.ReadLine();

		int numberOfPlates = GetNumberOfPlates();
		Console.WriteLine($"----------\nThere you go, {userName}. Good luck!\n");
		BingoPlatesCollection.AssignPlatesToUser(numberOfPlates);
	}

	static int GetNumberOfPlates()
	{
		int numberOfPlates;
		while (true)
		{
			Console.Write($"How many bingo plates would you like to play? You can choose up to {_maxPlates} plates: ");
			if (int.TryParse(Console.ReadLine(), out numberOfPlates) && numberOfPlates > 0 && numberOfPlates <= _maxPlates)
			{
				return numberOfPlates;
			}
			Console.WriteLine($"Please enter a number between 1 and {_maxPlates}.");
		}
	}
}