using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLib.Model
{
	public class Cell : ObservableObject
	{
		public Cell(int cellNumber)
		{
			this.cellNumber = cellNumber;
		}

		private int cellNumber;

		public int CellNumber
		{
			get
			{
				return cellNumber;
			}
		}

		private PlayerMove move;

		public PlayerMove Move
		{
			get
			{
				return move;
			}
			set
			{
				if (move == value)
				{
					return;
				}
				Set(ref move, value);
			}
		}
	}
}
