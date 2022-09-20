﻿using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghost : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("I am going to haunt you in your dreams!...");
        }

        public override int DefaultSpriteId => 314;
        public override string DefaultName => "Ghost";
    }
}
