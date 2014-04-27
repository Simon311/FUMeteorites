﻿using System;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace FUMeteoritesPlugin
{
    [ApiVersion(1, 15)]

    public class FUMeteorites : TerrariaPlugin
    {
        public override Version Version
        {
			get { return Assembly.GetExecutingAssembly().GetName().Version; }
        }
        public override string Name
        {
            get { return "FU Meteorites!"; }
        }
        public override string Author
        {
            get { return "Colin & Simon311"; }
        }
        public override string Description
        {
            get { return "Block meteorites from falling."; }
        }

        public FUMeteorites(Main game)
            : base(game)
        {
            Order = 5;
        }

		private static Config Cfg;

        public override void Initialize()
        {
			ServerApi.Hooks.GameUpdate.Register(this, OnUpdate, -1);
			Commands.ChatCommands.Add(new Command("worldgen.disables", Reload, "worldgenrl"));
			Cfg = Config.Read();
        }

		protected override void Dispose(bool disposing)
		{
			if (disposing) ServerApi.Hooks.GameUpdate.Deregister(this, OnUpdate);
			base.Dispose(disposing);
		}

		private void Reload(CommandArgs e)
		{
			Cfg = Config.Read();
			e.Player.SendSuccessMessage("WorldGen disables reload successfully!");
		}

        public static void OnUpdate(EventArgs e)
        {
			if (Cfg.disableMeteor) 
				WorldGen.spawnMeteor = false;

			if (Cfg.disableRain && Main.raining) 
				Main.StopRain();

			if (Cfg.disableBloodmoon)
				Main.bloodMoon = false;

			if (Cfg.disableEclipse) 
				Main.eclipse = false;

			if (Cfg.disableInvasions)
			{
				Main.invasionType = 0;
				Main.invasionSize = 0;
				Main.invasionDelay = 0;
				Main.invasionWarn = 0;
				Main.invasionX = 0.0;
			}

			if (Cfg.disablePumpkinMoon)
				Main.pumpkinMoon = false;

			if (Cfg.disableMoons)
			{
				Main.moonType = 0;
				Main.moonModY = 0;
			}
		}
    }
}