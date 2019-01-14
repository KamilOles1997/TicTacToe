using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TicTacToe.Model;
using TicTacToeLib.Model;

namespace TicTacToe.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// See http://www.mvvmlight.net
	/// </para>
	/// </summary>
	public class GameViewModel : ViewModelBase
	{
		private readonly IDataService _dataService;
		private Game game;
		private ICommand moveCommand;

		public ICommand MoveCommand
		{
			get
			{
				if (moveCommand == null)
				{
					moveCommand = new RelayCommand
						(cellnumber => this.Move(Convert.ToInt32(cellnumber)),
						cellnumber => this.CanMove(Convert.ToInt32(cellnumber)));
				}
				return moveCommand;
			}
		}
		public Game Game
		{
			get => game;
			set => Set(ref game, value);
		}

		/// <summary>
		/// Initializes a new instance of the GameViewModel class.
		/// </summary>
		public GameViewModel(IDataService dataService)
		{
			Game = new Game();
			_dataService = dataService;
			MessengerInstance.Register<string>(this, Tokens.SetPlayerX, (a) => SetPlayerXName(a));
			MessengerInstance.Register<string>(this, Tokens.SetPlayerO, (a) => SetPlayerOName(a));
			MessengerInstance.Register<string>(this, Tokens.StartGame, (a) => StartGame());
		}

		private bool CanMove(int cellNumber)
		{
			if(Game.CurrentPlayer == null)
			{
				return false;
			}

			if (Game.Cells[cellNumber].Move == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		private void Move(int cellNumber)
		{
			Game.Cells[cellNumber].Move = Game.CurrentPlayer;
			//cells[cellNumber].Move = new PlayerMove(currentPlayerName);

			//if (HasWon(currentPlayerName))
			//{
			//	RaiseGameOverEvent(new GameOverEventArgs()
			//	{
			//		IsTie = false,
			//		WinnerName = currentPlayerName
			//	});
			//	NewGame();
			//}
			//else if (TieGame())
			//{
			//	RaiseGameOverEvent(new GameOverEventArgs() { IsTie = true });
			//	NewGame();
			//}

			//else
			//{
			//	if (currentPlayerName.Equals("x"))
			//	{
			//		CurrentPlayerName = "o";
			//	}
			//	else
			//	{
			//		CurrentPlayerName = "x";
			//	}
			//}

			Game.CurrentPlayer = Game.CurrentPlayer == Game.PlayerCross ? Game.PlayerCircle : Game.PlayerCross;
		}

		public void StartGame()
		{
			MainSettings settings = MainSettings.LoadFromXML();
			Game.InRowToWin = settings.InRowToWin;
			Game.GameAreaSize = settings.GameAreaSize;

			ObservableCollection<Cell>  cells = new ObservableCollection<Cell>();

			for (int i = 0; i < settings.GameAreaSize * settings.GameAreaSize; i++)
			{
				cells.Add(new Cell(i));
			}

			Game.Cells = cells;

			Game.CurrentPlayer = Game.PlayerCross;
		}

		public void SetPlayerXName(string name)
		{
			Player p = new Player();
			p.Name = name;
			p.Type = "x";
			Game.PlayerCross = p;
		}

		public void SetPlayerOName(string name)
		{
			Player p = new Player();
			p.Name = name;
			p.Type = "o";
			Game.PlayerCircle = p;
		}

	}
}