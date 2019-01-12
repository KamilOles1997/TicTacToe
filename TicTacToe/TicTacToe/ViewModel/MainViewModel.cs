using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Windows.Input;
using TicTacToe.Model;

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
		

		public ICommand PlayViewCommand
		{
			get
			{
				if (playViewCommand == null)
				{
					playViewCommand = new RelayCommand(
							() => SetCurrentView(SimpleIoc.Default.GetInstance<GameViewModel>()),
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
					settingsViewCommand = new RelayCommand(
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
					aboutProgramCommand = new RelayCommand(
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

			}
			CurrentViewModel = vm;
		}

		private void OpenAboutDialog()
		{

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
		}

		////public override void Cleanup()
		////{
		////    // Clean up if needed

		////    base.Cleanup();
		////}
	}
}