namespace DefaultNamespace.Data
{
    public struct FiringData: IEffectData
    {
        public float Delay;
        public float Duration;
        public float FlameRate;
        public int FlameDamage;

        public FiringData(float _delay, float _duration, float _rate, int _damage)
        {
            Delay = _delay;
            Duration = _duration;
            FlameRate = _rate;
            FlameDamage = _damage;
        }
    }
}