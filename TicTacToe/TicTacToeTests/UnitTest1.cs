using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLib.Model;

namespace TicTacToeTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestLoadFromXML()
		{
			MainSettings settings = MainSettings.LoadFromXML("TestConfig\\Settings.xml");
			Assert.AreEqual(settings.Language, "PL");
		}

		[TestMethod]
		public void TestLoadFromXMLDefaultValues()
		{
			MainSettings settings = MainSettings.LoadFromXML("NonExistingFile.xml");
			Assert.AreEqual(settings.InRowToWin, 3);
		}

		[TestMethod]
		public void TestSaveToXml()
		{
			MainSettings settings = new MainSettings();
			settings.GameAreaSize = 10;
			settings.InRowToWin = 10;
			settings.Language = "pl";
			settings.SaveToXML("TestConfig\\Settings.xml");

			settings = MainSettings.LoadFromXML("TestConfig\\Settings.xml");
			Assert.AreEqual(settings.InRowToWin, 10);
		}

		[TestMethod]
		public void TestMove()
		{
			Game game = new Game();
			game.InRowToWin = 3;
			game.GameAreaSize = 3;
			game.Cells = new System.Collections.ObjectModel.ObservableCollection<Cell>();
			for(int i=0; i< game.GameAreaSize * game.GameAreaSize; i++)
			{
				game.Cells.Add(new Cell(i));
			}
			game.PlayerCircle = new Player() { Name = "O", Type = "o" };
			game.PlayerCross = new Player() { Name = "X", Type = "x" };
			game.CurrentPlayer = game.PlayerCross;

			game.Move(1);

			Assert.ReferenceEquals(game.CurrentPlayer, game.PlayerCross);
		}

		[TestMethod]
		public void TestCheckCOnditions()
		{
			Game game = new Game();
			game.InRowToWin = 3;
			game.GameAreaSize = 3;
			game.Cells = new System.Collections.ObjectModel.ObservableCollection<Cell>();
			for (int i = 0; i < game.GameAreaSize * game.GameAreaSize; i++)
			{
				game.Cells.Add(new Cell(i));
			}
			game.PlayerCircle = new Player() { Name = "O", Type = "o" };
			game.PlayerCross = new Player() { Name = "X", Type = "x" };
			game.CurrentPlayer = game.PlayerCross;
			game.Cells[0].Move = game.CurrentPlayer;
			game.Cells[1].Move = game.CurrentPlayer;
			game.Cells[2].Move = game.CurrentPlayer;


			bool result = game.CheckEndConditions(game.CurrentPlayer, 0);

			Assert.AreEqual(result, true);
		}
	}
}
