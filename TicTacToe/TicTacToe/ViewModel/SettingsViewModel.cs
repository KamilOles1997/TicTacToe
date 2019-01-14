using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
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
	public class SettingsViewModel : ViewModelBase
	{
		private readonly IDataService _dataService;
		private string selectedLanguage;
		private int selectedWin;
		private int selectedSize;
		private MainSettings settings;

		private ICommand comeBackComand;
		private ICommand saveCommand;

		public List<string> Languages { get; set; }
		public List<int> Sizes { get; set; }
		public List<int> Wins { get; set; }
		public MainSettings Settings
		{
			get
			{
				return settings;
			}
			set
			{
				Set(ref settings, value);
			}
		}

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

		public ICommand ComeBackComand
		{
			get
			{
				if (comeBackComand == null)
				{
					comeBackComand = new GalaSoft.MvvmLight.Command.RelayCommand(
							() => MessengerInstance.Send<string>(String.Empty,Tokens.BackToMainView),
							() => true
						);
				}
				return comeBackComand;
			}
		}

		public ICommand SaveCommand
		{
			get
			{
				if (saveCommand == null)
				{
					saveCommand = new GalaSoft.MvvmLight.Command.RelayCommand(
							() => SaveSettings(),
							() => true
						);
				}
				return saveCommand;
			}
		}


		/// <summary>
		/// Initializes a new instance of the SettingsViewModel class.
		/// </summary>
		public SettingsViewModel(IDataService dataService)
		{
			_dataService = dataService;

			Languages = new List<string>() { "EN", "PL" };
			Sizes = new List<int>() { 3, 4, 5, 6, 7, 8 };
			Wins = new List<int>() { 3, 4, 5 };

			MessengerInstance.Register<MainSettings>(this, Tokens.OpenSettings, settings =>
			{
				SetSettings(settings);
			});
		}

		public void SetSettings(MainSettings settings)
		{
			Settings = settings;
			SelectedLanguage = Settings.Language;
			SelectedSize = Settings.GameAreaSize;
			SelectedWin = Settings.InRowToWin;
		}

		public void SaveSettings()
		{
			Settings = new MainSettings();
			Settings.Language = SelectedLanguage;
			Settings.InRowToWin = SelectedWin;
			Settings.GameAreaSize = SelectedSize;

			Settings.SaveToXML();
			MessengerInstance.Send<string>(String.Empty, Tokens.BackToMainView);

		}

	}
}