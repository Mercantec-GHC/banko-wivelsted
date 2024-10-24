namespace BankoConsol
{ 
	public class Program
	{
		static void Main(string[] args)
		{
			BingoPlatesCollection.InitializeBingoPlates();
			InteractingWithUser.ShowGreeting();
			InteractingWithUser.GetUserInputAndGenerateAssignedPlates();
			Game.PlayGame();
		}
	}
}