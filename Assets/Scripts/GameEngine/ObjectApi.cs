namespace GameEngine
{
    public static class ObjectApi
    {
        public const string AttackAction = nameof(AttackAction);
        public const string MoveDirection = nameof(MoveDirection);
        public const string DeathEvent = nameof(DeathEvent);
    }

    public static class HealthAPI
    {
        public const string IsAlive = nameof(IsAlive);
        public const string TakeDamageAction = nameof(TakeDamageAction);
        public const string Damageable = nameof(Damageable);
    }
}