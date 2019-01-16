using System.Windows;
using GalaSoft.MvvmLight.Threading;
using TicTacToeLib.Model;

namespace TicTacToe
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		static App()
		{
			DispatcherHelper.Initialize();

			string lang = MainSettings.LoadFromXML().Language;
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang); 
		}
	}
}
