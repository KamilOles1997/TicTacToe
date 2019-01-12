using GalaSoft.MvvmLight;
using System.Collections.Generic;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// See http://www.mvvmlight.net
	/// </para>
	/// </summary>
	public class SettingsViewModel : ViewModelBase
	{
		private readonly IDataService _dataService;
		private string selectedLanguage;
		private int selectedWin;
		private int selectedSize;

		public List<string> Languages { get; set; }
		public List<int> Sizes { get; set; }
		public List<int> Wins { get; set; }

		public string SelectedLanguage
		{
			get => selectedLanguage;
			set => Set(ref selectedLanguage, value);
		}

		public int SelectedWin
		{
			get => selectedWin;
			set => Set(ref selectedWin, value);
		}

		public int SelectedSize
		{
			get => selectedSize;
			set => Set(ref selectedSize, value);
		}

		/// <summary>
		/// Initializes a new instance of the SettingsViewModel class.
		/// </summary>
		public SettingsViewModel(IDataService dataService)
		{
			_dataService = dataService;

			Languages = new List<string>() { "EN", "DE" };
			Sizes = new List<int>() { 3, 4, 5, 6, 7, 8 };
			Wins = new List<int>() { 3, 4, 5 };

		}

	}
}