using System;
using System.Collections.Generic;
using System.Text;

namespace SiriusSudoku
{
	[Serializable()]
	public class Player
	{
		public string PlayerName { get; set; }
		public int TooEasyNumberOfGamesPlayed { get; set; }
		public int EasyNumberOfGamesPlayed { get; set; }
		public int MediumNumberOfGamesPlayed { get; set; }
		public int HardNumberOfGamesPlayed { get; set; }
		public int ExtremeNumberOfGamesPlayed { get; set; }
		public int SillyHardNumberOfGamesPlayed { get; set; }
		public int TooEasyBestTime { get; set; }
		public int EasyBestTime { get; set; }
		public int MediumBestTime { get; set; }
		public int HardBestTime { get; set; }
		public int ExtremeBestTime { get; set; }
		public int SillyHardBestTime { get; set; }
		public float TooEasyAverageTime { get; set; }
		public float EasyAverageTime { get; set; }
		public float MediumAverageTime { get; set; }
		public float HardAverageTime { get; set; }
		public float ExtremeAverageTime { get; set; }
		public float SillyHardAverageTime { get; set; }

		public override string ToString()
		{
			return PlayerName;
		}

		public int NumberOfGamesPlayed(Difficulty gameDifficulty)
		{
			switch (gameDifficulty)
			{
				case Difficulty.TooEasy:
					return TooEasyNumberOfGamesPlayed;
				case Difficulty.Easy:
					return EasyNumberOfGamesPlayed;
				case Difficulty.Medium:
					return MediumNumberOfGamesPlayed;
				case Difficulty.Hard:
					return HardNumberOfGamesPlayed;
				case Difficulty.Extreme:
					return ExtremeNumberOfGamesPlayed;
				case Difficulty.SillyHard:
					return SillyHardNumberOfGamesPlayed;
				default:
					return 0;
			}
		}

		public int BestTime(Difficulty gameDifficulty)
		{
			switch (gameDifficulty)
			{
				case Difficulty.TooEasy:
					return TooEasyBestTime;
				case Difficulty.Easy:
					return EasyBestTime;
				case Difficulty.Medium:
					return MediumBestTime;
				case Difficulty.Hard:
					return HardBestTime;
				case Difficulty.Extreme:
					return ExtremeBestTime;
				case Difficulty.SillyHard:
					return SillyHardBestTime;
				default:
					return 0;
			}
		}

		public float AverageTime(Difficulty gameDifficulty)
		{
			switch (gameDifficulty)
			{
				case Difficulty.TooEasy:
					return TooEasyAverageTime;
				case Difficulty.Easy:
					return EasyAverageTime;
				case Difficulty.Medium:
					return MediumAverageTime;
				case Difficulty.Hard:
					return HardAverageTime;
				case Difficulty.Extreme:
					return ExtremeAverageTime;
				case Difficulty.SillyHard:
					return SillyHardAverageTime;
				default:
					return 0;
			}
		}

		public void SetNumberOfGamesPlayed(Difficulty gameDifficulty, int gamesPlayed)
		{
			switch (gameDifficulty)
			{
				case Difficulty.TooEasy:
					TooEasyNumberOfGamesPlayed = gamesPlayed;
					break;
				case Difficulty.Easy:
					EasyNumberOfGamesPlayed = gamesPlayed;
					break;
				case Difficulty.Medium:
					MediumNumberOfGamesPlayed = gamesPlayed;
					break;
				case Difficulty.Hard:
					HardNumberOfGamesPlayed = gamesPlayed;
					break;
				case Difficulty.Extreme:
					ExtremeNumberOfGamesPlayed = gamesPlayed;
					break;
				case Difficulty.SillyHard:
					SillyHardNumberOfGamesPlayed = gamesPlayed;
					break;
			}
		}

		public void SetBestTime(Difficulty gameDifficulty, int gameDuration)
		{
			switch (gameDifficulty)
			{
				case Difficulty.TooEasy:
					TooEasyBestTime = gameDuration;
					break;
				case Difficulty.Easy:
					EasyBestTime = gameDuration;
					break;
				case Difficulty.Medium:
					MediumBestTime = gameDuration;
					break;
				case Difficulty.Hard:
					HardBestTime = gameDuration;
					break;
				case Difficulty.Extreme:
					ExtremeBestTime = gameDuration;
					break;
				case Difficulty.SillyHard:
					SillyHardBestTime = gameDuration;
					break;
			}
		}

		public void SetAverageTime(Difficulty gameDifficulty, float newAverage)
		{
			switch (gameDifficulty)
			{
				case Difficulty.TooEasy:
					TooEasyAverageTime = newAverage;
					break;
				case Difficulty.Easy:
					EasyAverageTime = newAverage;
					break;
				case Difficulty.Medium:
					MediumAverageTime = newAverage;
					break;
				case Difficulty.Hard:
					HardAverageTime = newAverage;
					break;
				case Difficulty.Extreme:
					ExtremeAverageTime = newAverage;
					break;
				case Difficulty.SillyHard:
					SillyHardAverageTime = newAverage;
					break;
			}
		}
	}
}
