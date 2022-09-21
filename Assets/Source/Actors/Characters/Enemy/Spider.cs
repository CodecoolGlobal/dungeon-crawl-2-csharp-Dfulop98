﻿using UnityEngine;

namespace Assets.Source.Actors.Characters.Enemy
{
    public class Spider : Enemy
    {
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 30;
        public override int ScoreValue { get; set; } = 10;

        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";
        protected override void OnDeathFeedBack()
        {
            Debug.Log("Spider noises...");
        }
    }
}