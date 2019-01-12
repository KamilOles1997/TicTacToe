using System;
using TicTacToeLib.Model;

namespace TicTacToe.Model
{
	public class DataService : IDataService
	{
		public void GetMainSettings(Action<MainSettings, Exception> callback)
		{
			try
			{
				MainSettings settings = MainSettings.LoadFromXML();
				callback(settings, null);
			}
			catch(Exception ex)
			{
				callback(null, ex);
			}
		}
	}
}