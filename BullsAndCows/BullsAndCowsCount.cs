namespace BullsAndCowsComplete
{
	public class BullsAndCowsCount
	{
		public int Bulls { get; set; }
		public int Cows { get; set; }

		public BullsAndCowsCount(int bullCount, int cowCount)
		{
			Bulls = bullCount;
			Cows = cowCount;
		}
	}
}
