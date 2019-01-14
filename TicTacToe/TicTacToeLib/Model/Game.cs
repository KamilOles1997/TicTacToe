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
	}
}
