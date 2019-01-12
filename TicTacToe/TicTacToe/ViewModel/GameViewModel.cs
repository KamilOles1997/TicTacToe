using GalaSoft.MvvmLight;
using TicTacToe.Model;

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

		/// <summary>
		/// Initializes a new instance of the GameViewModel class.
		/// </summary>
		public GameViewModel(IDataService dataService)
		{
			_dataService = dataService;
		}

	}
}