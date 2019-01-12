using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
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
		private ObservableCollection<Cell> cells; 

		public ObservableCollection<Cell> Cells
		{
			get => cells;
			set => Set(ref cells, value);
		}
		/// <summary>
		/// Initializes a new instance of the GameViewModel class.
		/// </summary>
		public GameViewModel(IDataService dataService)
		{
			_dataService = dataService;

			int dimension = 4;
			Cells = new ObservableCollection<Cell>();

			for (int i = 0; i<dimension* dimension; i++)
			{
				Cells.Add(new Cell(i));
			}  
		}

	}
}