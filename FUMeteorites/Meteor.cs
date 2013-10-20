﻿using System;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;

namespace FUMeteoritesPlugin
{
    [ApiVersion(1, 14)]

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
            Order = -4;
        }
        public override void Initialize()
        {
			ServerApi.Hooks.GameUpdate.Register(this, OnUpdate);
        }

		protected override void Dispose(bool disposing)
		{
			if (disposing) ServerApi.Hooks.GameUpdate.Deregister(this, OnUpdate);
		}

        public static void OnUpdate(EventArgs e)
        {
            WorldGen.spawnMeteor = false;
        }
    }
}