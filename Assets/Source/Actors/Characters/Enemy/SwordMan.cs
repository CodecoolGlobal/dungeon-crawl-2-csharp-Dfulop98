namespace Assets.Source.Actors.Characters.Enemy
{
    public class SwordMan : Enemy
    {
        public override char MapIcon => 'q';
        public override int Damage { get; set; } = 25;
        public override int Health { get; set; } = 30;
        public override int ScoreValue { get; set; } = 20;

        public override string DefaultSpriteId => "PackCastle01_55";
        public override string DefaultName => "KardosJános";
    }
}
