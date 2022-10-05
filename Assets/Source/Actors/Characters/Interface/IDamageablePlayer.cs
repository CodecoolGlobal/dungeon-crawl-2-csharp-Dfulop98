namespace DungeonCrawl.Actors.Characters
{
    internal interface IDamageablePlayer : IDamageable
    {
        public void OnDeath();
        public void ApplyDamage(Enemy enemy);
    }
}
