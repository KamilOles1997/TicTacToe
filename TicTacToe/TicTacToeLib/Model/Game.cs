using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLib.Model
{
	public class Game : ObservableObject
	{
		public int GameAreaSize { get; set; }
		public int InRowToWin { get; set; }

		private Player currentPlayer;
		private Player playerCross;
		private Player playerCircle;
		private ObservableCollection<Cell> cells;

		public event Func<Player,Task<Player>> GameEndedWin;
		public event Action GameEndedNoWin;


		public Player CurrentPlayer
		{
			get => currentPlayer;
			set => Set(ref currentPlayer, value);
		}

		public ObservableCollection<Cell> Cells
		{
			get => cells;
			set => Set(ref cells, value);
		}

		public Player PlayerCross
		{
			get => playerCross;
			set => Set(ref playerCross, value);
		}

		public Player PlayerCircle
		{
			get => playerCircle;
			set => Set(ref playerCircle, value);
		}

		public void Move(int cellNumber)
		{
			Cells[cellNumber].Move = CurrentPlayer;
			CheckEndConditions(CurrentPlayer, cellNumber);
			CurrentPlayer = CurrentPlayer == PlayerCross ? PlayerCircle : PlayerCross;
		}

		public bool CheckEndConditions(Player player, int cellNumber)
		{
			bool hasPlayerWon = false; ;
			List<int> playerMoves = Cells.Where(a => a.Move == player).Select(a => a.CellNumber).ToList();
			List<int> first = GenerateFirstCheck(cellNumber);
			List<int> second = GenerateSecondCheck(cellNumber);
			List<int> third = GenerateThirdCheck(cellNumber);
			List<int> fourth = GenerateFourthCheck(cellNumber);
			List<int> fifth = GenerateFifthCheck(cellNumber);
			List<int> sixth = GenerateSixhCheck(cellNumber);
			List<int> seveth = GenerateSeventhCheck(cellNumber);
			List<int> eigth = GenerateEigthCheck(cellNumber);

			if (playerMoves.Intersect(first).Count() == first.Count())
			{
				hasPlayerWon = true;
			}
			if (playerMoves.Intersect(second).Count() == second.Count())
			{
				hasPlayerWon = true;
			}
			if (playerMoves.Intersect(third).Count() == third.Count())
			{
				hasPlayerWon = true;
			}
			if (playerMoves.Intersect(fourth).Count() == fourth.Count())
			{
				hasPlayerWon = true;
			}
			if (playerMoves.Intersect(fifth).Count() == fifth.Count())
			{
				hasPlayerWon = true;
			}
			if (playerMoves.Intersect(sixth).Count() == sixth.Count())
			{
				hasPlayerWon = true;
			}
			if (playerMoves.Intersect(seveth).Count() == seveth.Count())
			{
				hasPlayerWon = true;
			}
			if (playerMoves.Intersect(eigth).Count() == eigth.Count())
			{
				hasPlayerWon = true;
			}


			if (hasPlayerWon)
			{
				GameEndedWin?.Invoke(player);
			}
			else
			{
				if (!Cells.Any(a => a.Move == null))
				{
					GameEndedNoWin?.Invoke();
				}
			}
			return hasPlayerWon;
		}

		private List<int> GenerateFirstCheck(int cellNumber)
		{
			List<int> lista = new List<int>();
			lista.Add(cellNumber);
			for(int i = 1; i<InRowToWin; i++)
			{
				lista.Add(lista.Last() + 1);
			}
			return lista;
		}

		private List<int> GenerateSecondCheck(int cellNumber)
		{
			List<int> lista = new List<int>();
			lista.Add(cellNumber);
			for (int i = 1; i < InRowToWin; i++)
			{
				lista.Add(lista.Last() + GameAreaSize);
			}
			return lista;
		}

		private List<int> GenerateThirdCheck(int cellNumber)
		{
			List<int> lista = new List<int>();
			lista.Add(cellNumber);
			for (int i = 1; i < InRowToWin; i++)
			{
				lista.Add(lista.Last() + GameAreaSize + 1);
			}
			return lista;
		}

		private List<int> GenerateFourthCheck(int cellNumber)
		{
			List<int> lista = new List<int>();
			lista.Add(cellNumber);
			for (int i = 1; i < InRowToWin; i++)
			{
				lista.Add(lista.Last() + GameAreaSize - 1);
			}
			return lista;
		}

		private List<int> GenerateFifthCheck(int cellNumber)
		{
			List<int> lista = new List<int>();
			lista.Add(cellNumber);
			for (int i = 1; i < InRowToWin; i++)
			{
				lista.Add(lista.Last() - 1);
			}
			return lista;
		}

		private List<int> GenerateSixhCheck(int cellNumber)
		{
			List<int> lista = new List<int>();
			lista.Add(cellNumber);
			for (int i = 1; i < InRowToWin; i++)
			{
				lista.Add(lista.Last() - GameAreaSize);
			}
			return lista;
		}

		private List<int> GenerateSeventhCheck(int cellNumber)
		{
			List<int> lista = new List<int>();
			lista.Add(cellNumber);
			for (int i = 1; i < InRowToWin; i++)
			{
				lista.Add(lista.Last() - GameAreaSize + 1);
			}
			return lista;
		}

		private List<int> GenerateEigthCheck(int cellNumber)
		{
			List<int> lista = new List<int>();
			lista.Add(cellNumber);
			for (int i = 1; i < InRowToWin; i++)
			{
				lista.Add(lista.Last() - GameAreaSize - 1);
			}
			return lista;
		}
	}
}
