namespace Assets.Source.Actors.Characters.Enemy
{
    public class AxeMan : Enemy
    {
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 20;
        public override int ScoreValue { get; set; } = 10;
        
        public override string DefaultSpriteId => "PackCastle01_54";
        public override string DefaultName => "BaltásJános";
    }
}
