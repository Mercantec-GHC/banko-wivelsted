public static class BingoPlatesCollection
{
	private static List<List<int[]>> bingoPlates = new();
	public static List<List<int[]>> Plates => bingoPlates;
	private static List<int> _userPlateIds = new();
	//	{
	//	get { return bingoPlates; }
	//  }

	public static void InitializeBingoPlates()
	{
		
		bingoPlates.Add(new List<int[]>
			{
				new int[] { 1, 0, 23, 0, 44, 0, 0, 74, 81 },
				new int[] { 0, 15, 0, 38, 0, 55, 63, 0, 88 },
				new int[] { 5, 0, 25, 39, 0, 0, 67, 0, 90 }
			});

		bingoPlates.Add(new List<int[]>
			{
				new int[] { 2, 10, 0, 33, 0, 0, 65, 0, 81 },
				new int[] { 0, 13, 26, 0, 49, 0, 0, 72, 84 },
				new int[] { 6, 0, 27, 34, 0, 59, 0, 78, 0 }
			});

		bingoPlates.Add(new List<int[]>
			{
				new int[] { 0, 14, 0, 31, 0, 0, 60, 70, 84 },
				new int[] { 3, 0, 25, 37, 0, 58, 0, 76, 0 },
				new int[] { 7, 17, 0, 0, 46, 0, 68, 0, 89 }
			});

		bingoPlates.Add(new List<int[]>
			{
				new int[] { 7, 0, 22, 0, 40, 53, 0, 0, 80 },
				new int[] { 0, 12, 0, 34, 0, 0, 61, 71, 83 },
				new int[] { 9, 18, 0, 0, 45, 0, 69, 0, 90 }
			});

		bingoPlates.Add(new List<int[]>
			{
				new int[] { 4, 0, 25, 30, 0, 0, 62, 0, 85 },
				new int[] { 0, 16, 28, 0, 46, 54, 0, 77, 0 },
				new int[] { 9, 13, 0, 0, 41, 0, 0, 73, 0 }
			});

		bingoPlates.Add(new List<int[]>
			{
				new int[] { 0, 11, 0, 32, 0, 57, 62, 0, 82 },
				new int[] { 8, 0, 23, 0, 47, 0, 66, 0, 86 },
				new int[] { 0, 19, 0, 36, 48, 58, 0, 75, 0 }
			});
	}

	public static void AssignPlatesToUser(int numberOfPlates)
	{
		var _userPlates = InteractingWithUser.UserPlates;
		var plates = Plates;
		for (int i = 0; i < numberOfPlates; i++)
		{
			if (i < plates.Count)
			{
				_userPlates.Add(plates[i]);
				_userPlateIds.Add(i + 1);
				Console.WriteLine($"Plate ID: {i + 1}");
				PrintBingoPlate(plates[i]);
			}
		}
	}
	public static void PrintBingoPlate(List<int[]> plate)
	{
		foreach (var row in plate)
		{
			Console.WriteLine("+----+----+----+----+----+----+----+----+----+");
			Console.WriteLine("| " + string.Join(" | ", row.Select(n => (n == -1 ? "XX" : (n == 0 ? "  " : n.ToString("00"))))) + " |");
		}
		Console.WriteLine("+----+----+----+----+----+----+----+----+----+");
		Console.WriteLine();
	}
}