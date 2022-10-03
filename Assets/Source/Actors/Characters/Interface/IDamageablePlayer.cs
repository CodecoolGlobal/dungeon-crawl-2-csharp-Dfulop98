namespace Assets.Source.Actors.Characters
{
    internal interface IDamageablePlayer : IDamageable
    {
        public void OnDeath();
        public void ApplyDamage(Enemy.Enemy enemy);
    }
}
