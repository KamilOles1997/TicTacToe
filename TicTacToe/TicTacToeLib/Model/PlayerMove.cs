using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLib.Model
{
	public class PlayerMove : ObservableObject
	{
		string playerName;

		public string PlayerName
		{
			get
			{
				return playerName;
			}
			set
			{
				if (string.Compare(playerName, value) == 0)
				{
					return;
				}
				Set(ref playerName, value);
			}
		}

		bool isPartOfWin = false;

		public bool IsPartOfWin
		{
			get
			{
				return isPartOfWin;
			}
			set
			{
				if (isPartOfWin == value)
				{
					return;
				}
				Set(ref isPartOfWin, value);
			}
		}

		public PlayerMove(string playerName)
		{
			this.playerName = playerName;
		}
	}
}
