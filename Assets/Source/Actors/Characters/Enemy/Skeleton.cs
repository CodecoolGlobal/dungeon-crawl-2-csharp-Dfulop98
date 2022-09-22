using UnityEngine;

namespace Assets.Source.Actors.Characters.Enemy
{
    public class Skeleton : Enemy
    {
        public override int Damage { get; set; } = 5;
        public override int Health { get; set; } = 10;
        public override int ScoreValue { get; set; } = 10;

        public override string DefaultSpriteId => "PackCastle01_4";
        public override string DefaultName => "Skeleton";
    }
}
