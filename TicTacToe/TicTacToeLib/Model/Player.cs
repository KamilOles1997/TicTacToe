using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLib.Model
{
	public class Player : ObservableObject
	{
		private string name;
		private string type;

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				Set(ref name, value);
			}
		}

		public string Type
		{
			get
			{
				return type;
			}
			set
			{
				Set(ref type, value);
			}
		}

	}
}
