using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TicTacToeLib.Model
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName = "MainSettings")]
	public partial class MainSettings
	{
		private int inRowToWin;
		private int gameAreaSize;
		private string language;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string Language
		{
			get => language;
			set => language = value;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public int InRowToWin
		{
			get => inRowToWin;
			set => inRowToWin = value;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public int GameAreaSize
		{
			get => gameAreaSize;
			set => gameAreaSize = value;
		}



		public static MainSettings LoadFromXML(string settingsPath = "Config\\Setings.xml")
		{
			try
			{
				if (!File.Exists(settingsPath))
				{
					MainSettings settings = new MainSettings();
					settings.Language = "PL";
					settings.InRowToWin = 4;
					settings.GameAreaSize = 6;

					settings.SaveToXML();
					return settings;
				}
				else
				{
					XmlSerializer serializer = new XmlSerializer(typeof(MainSettings));
					using (XmlReader reader = XmlReader.Create(settingsPath))
					{
						MainSettings settings = (MainSettings)(serializer.Deserialize(reader));
						return settings;
					}
				}

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public void SaveToXML(string settingsPath = "Config\\Setings.xml")
		{
			try
			{
				XmlSerializer xs = new XmlSerializer(typeof(MainSettings));
				using (TextWriter tw = new StreamWriter(settingsPath))
				{
					xs.Serialize(tw, this);
				}

			}
			catch (Exception ex)
			{
				return;
			}
		}
	}
}
