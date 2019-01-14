using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls.Dialogs;
using System;
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
	public class MainViewModel : ViewModelBase
	{
		private readonly IDataService _dataService;
		private ViewModelBase currentViewModel;
		private ICommand playViewCommand;
		private ICommand settingsViewCommand;
		private ICommand aboutProgramCommand;
		private ResourceDictionary DialogDictionary = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Dialogs.xaml") };


		public ICommand PlayViewCommand
		{
			get
			{
				if (playViewCommand == null)
				{
					playViewCommand = new GalaSoft.MvvmLight.Command.RelayCommand(
							() => ShowDialog(),
							() => true
						);
				}
				return playViewCommand;
			}
		}

		public ICommand SettingsViewCommand
		{
			get
			{
				if (settingsViewCommand == null)
				{
					settingsViewCommand = new GalaSoft.MvvmLight.Command.RelayCommand(
							() => SetCurrentView(SimpleIoc.Default.GetInstance<SettingsViewModel>()),
							() => true
						);
				}
				return settingsViewCommand;
			}
		}

		public ICommand AboutProgramCommand
		{
			get
			{
				if (aboutProgramCommand == null)
				{
					aboutProgramCommand = new GalaSoft.MvvmLight.Command.RelayCommand(
							() => OpenAboutDialog(),
							() => true
						);
				}
				return aboutProgramCommand;
			}
		}
		
		private void SetCurrentView(ViewModelBase vm)
		{
			if(vm is GameViewModel)
			{

			}
			else if(vm is SettingsViewModel)
			{
				MessengerInstance.Send<MainSettings>(MainSettings.LoadFromXML(), Tokens.OpenSettings);
			}
			CurrentViewModel = vm;
		}

		private async void OpenAboutDialog()
		{
			var metroDialogSettings = new MetroDialogSettings
			{
				CustomResourceDictionary = DialogDictionary,
			};
			string message = "Wykorzystany Framework: \n-MVVM Light \n\nWykorzystane biblioteki: \n-MahApps.Metro \n-MaterialDesignThemes \n-ControlzEx \n-CommonServiceLocator";
			await DialogCoordinator.Instance.ShowMessageAsync(this, Resources.r1, message, MessageDialogStyle.Affirmative, metroDialogSettings);
		}

		public ViewModelBase CurrentViewModel
		{
			get => currentViewModel;
			set => Set(ref currentViewModel, value);
		}

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IDataService dataService)
		{
			_dataService = dataService;
			CurrentViewModel = this;
			MessengerInstance.Register<string>(this, Tokens.BackToMainView, (a) => SetCurrentView(this));
		}

		public async void ShowDialog()
		{
			var metroDialogSettings = new MetroDialogSettings
			{
				CustomResourceDictionary = DialogDictionary,
			};

			string playerX = await DialogCoordinator.Instance.ShowInputAsync(this, Resources.r1, Resources.r13, metroDialogSettings);			;
			string playerO = await DialogCoordinator.Instance.ShowInputAsync(this, Resources.r1, Resources.r14, metroDialogSettings); ;

			SetCurrentView(SimpleIoc.Default.GetInstance<GameViewModel>());
			MessengerInstance.Send<string>(playerX, Tokens.SetPlayerX);
			MessengerInstance.Send<string>(playerO, Tokens.SetPlayerO);
			MessengerInstance.Send<string>(String.Empty, Tokens.StartGame);
		}

		////public override void Cleanup()
		////{
		////    // Clean up if needed

		////    base.Cleanup();
		////}
	}
}