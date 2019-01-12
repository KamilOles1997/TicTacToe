using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToeLib.Model;

namespace TicTacToe.Model
{
	public interface IDataService
	{
		void GetMainSettings(Action<MainSettings, Exception> callback);
	}
}
