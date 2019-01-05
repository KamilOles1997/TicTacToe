using System.Windows;
using GalaSoft.MvvmLight.Threading;

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
			//System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en"); 
		}
	}
}
