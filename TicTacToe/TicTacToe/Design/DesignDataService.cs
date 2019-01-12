using System;
using TicTacToe.Model;
using TicTacToeLib.Model;

namespace TicTacToe.Design
{
	public class DesignDataService : IDataService
	{
		public void GetMainSettings(Action<MainSettings, Exception> callback)
		{
			try
			{
				MainSettings settings = new MainSettings();
				settings.GameAreaSize = 5;
				settings.InRowToWin = 4;
				settings.Language = "PL";
				callback(settings, null);
			}
			catch (Exception ex)
			{
				callback(null, ex);
			}
		}
	}
}