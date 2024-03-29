﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors
{
    public class Crosshair : Actor
    {
        public override char MapIcon => ')';
        public override string DefaultName => "Crosshair";
        public override string DefaultSpriteId => "Crosshair";
        public override bool Detectable => false;
        public override int Z { get; } = -2;
        public int Offset;

        public void Move(Player player)
        {
            switch (player.Facing)
            {
                case (Direction.Left):
                    this.Position = (player.Position.x - Offset, player.Position.y);
                    break;
                case (Direction.Right):
                    this.Position = (player.Position.x + Offset, player.Position.y);
                    break;
                case (Direction.Up):
                    this.Position = (player.Position.x, player.Position.y + Offset);
                    break;
                case (Direction.Down):
                    this.Position = (player.Position.x, player.Position.y - Offset);
                    break;
            }
        }
    }
}
