using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TicTacToe.Model;
using TicTacToe.Properties;
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
		private ResourceDictionary DialogDictionary = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Dialogs.xaml") };

		public ICommand MoveCommand
		{
			get
			{
				if (moveCommand == null)
				{
					moveCommand = new RelayCommand
						(cellnumber => this.Game.Move(Convert.ToInt32(cellnumber)),
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
			Game.GameEndedNoWin += Game_GameEndedNoWin;
			Game.GameEndedWin += Game_GameEndedWin;

			_dataService = dataService;
			MessengerInstance.Register<string>(this, Tokens.SetPlayerX, (a) => SetPlayerXName(a));
			MessengerInstance.Register<string>(this, Tokens.SetPlayerO, (a) => SetPlayerOName(a));
			MessengerInstance.Register<string>(this, Tokens.StartGame, (a) => StartGame());
		}

		private async Task<Player> Game_GameEndedWin(Player arg)
		{
			var metroDialogSettings = new MetroDialogSettings
			{
				CustomResourceDictionary = DialogDictionary,
			};
			string message = Resources.r15 + arg.Name;
			await DialogCoordinator.Instance.ShowMessageAsync(this, Resources.r1, message, MessageDialogStyle.Affirmative, metroDialogSettings);
			MessengerInstance.Send<string>(String.Empty, Tokens.BackToMainView);
			return arg;
		}

		private async void Game_GameEndedNoWin()
		{
			var metroDialogSettings = new MetroDialogSettings
			{
				CustomResourceDictionary = DialogDictionary,
			};
			string message = Resources.r16;
			await DialogCoordinator.Instance.ShowMessageAsync(this, Resources.r1, message, MessageDialogStyle.Affirmative, metroDialogSettings);
			MessengerInstance.Send<string>(String.Empty, Tokens.BackToMainView);
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