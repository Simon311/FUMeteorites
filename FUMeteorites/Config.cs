using System;
using System.IO;
using Newtonsoft.Json;
using TShockAPI;

namespace FUMeteoritesPlugin
{
	public class Config
	{
		public bool disableMeteor = false;
		public bool disableRain = false;
		public bool disableBloodmoon = false;
		public bool disableEclipse = false;
		public bool disableInvasions = false;
		public bool disablePumpkinMoon = false;
		public bool disableMoons = false;

		public static string ConfigPath
		{
			get
			{
				return Path.Combine(TShock.SavePath, "disables.json");
			}
		}

		public static Config Read()
		{
			if (!File.Exists(ConfigPath))
				File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(new Config() { disableMeteor = true }, Formatting.Indented));

			return JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigPath));
		}

		public void Write()
		{
			File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(this, Formatting.Indented));
		}
	}
}
