using System;

public static class Game
{
	private static List<int> _userPlateIds = new();
	public static void PlayGame()
	{
		Console.WriteLine("Let's play some Bingo now!");
		Console.WriteLine();

		bool isGameOver = false;

		while (!isGameOver)
		{
			var plates = InteractingWithUser.UserPlates;
			
			Console.Write("\nEnter a random number between 1 and 90: ");

			if (!int.TryParse(Console.ReadLine(), out int chosenNumber))
			{
				Console.WriteLine("Invalid input. Please enter a number.");
				continue;
			}

			if (chosenNumber == 0)
			{
				Console.WriteLine("Sorry, someone else got Bingo before you.");
				isGameOver = true;
				break;
			}

			if (chosenNumber < 1 || chosenNumber > 90)
			{
				Console.WriteLine("Incorrect number. Please enter a number between 1 and 90.");
				continue;
			}
			Console.Clear();
			MarkNumberOnPlates(chosenNumber);
			CheckForWinningRows(plates);
		}
		Console.WriteLine("Game Over.");
	}

	static void MarkNumberOnPlates(int chosenNumber)
	{
		var plates = InteractingWithUser.UserPlates;
		bool numberFound = false;

		foreach (var plate in plates)
		{
			foreach (var row in plate)
			{
				for (int i = 0; i < row.Length; i++)
				{
					if (row[i] == chosenNumber)
					{
						row[i] = -1;
						numberFound = true;
						Console.WriteLine($"The number {chosenNumber} was found in this plate:");
					}
				}
			}
			BingoPlatesCollection.PrintBingoPlate(plate);
		}
	}

	static void CheckForWinningRows(List<List<int[]>> plates)
	{
		_userPlateIds = new List<int>();
		bool isFullRow = false;

		for (int i = 0; i < plates.Count; i++)
		{
			var plate = plates[i];
			int winningRows = 0;

			 winningRows = plate.Count(row => row.Count(n => n == -1) == 5);

			//foreach (var row in plate)
			//{
			//	int markedNumbers = 0;
			//	foreach (var number in row)
			//	{
			//		if (number == -1)
			//		{
			//			markedNumbers++;
			//		}
			//	}

			//	if (markedNumbers == 5)
			//	{
			//		winningRows++;
			//	}
			//}
			if (winningRows == 1 && !isFullRow)
			{
				Console.WriteLine($"\aBingo! You have 1 full row in Plate ID: {i + 1}!");
				isFullRow = true;
			}

			else if (winningRows == 2)
			{
				Console.WriteLine($"\aDouble Bingo! You have two full rows in Plate ID: {i + 1}!");
				isFullRow = true;
			}

			else if (winningRows == 3)
			{
				Console.WriteLine($"\aWin! All rows have been marked in Plate ID: {i + 1}!");
				Console.WriteLine("Game Over.");
				Environment.Exit(0);
			}
		}
	}
}