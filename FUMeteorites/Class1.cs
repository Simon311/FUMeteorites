﻿using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Terraria;
using Hooks;
using TShockAPI;
using TShockAPI.DB;
using System.ComponentModel;

namespace FUMeteoritesPlugin
{
    [APIVersion(1, 12)]

    public class FUMeteorites : TerrariaPlugin
    {
        public override Version Version
        {
            get { return new Version("1.0"); }
        }
        public override string Name
        {
            get { return "FU Meteorites!"; }
        }
        public override string Author
        {
            get { return "Colin"; }
        }
        public override string Description
        {
            get { return "Block meteorites from falling."; }
        }

        public FUMeteorites(Main game)
            : base(game)
        {
            Order = 4;
        }
        public override void Initialize()
        {
            GameHooks.Update += GameHooks_Update;
        }

        void GameHooks_Update()
        {
            WorldGen.spawnMeteor = false;
        }
    }
}