using System;

namespace Zork.Common
{
    public class Enemy
    {
        public string Name { get; }

        public string LookDescription { get; }

        public float Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (_health != value)
                {
                    _health = value;
                    HealthChanged?.Invoke(this, _health);
                }
            }
        }

        public event EventHandler<float> HealthChanged;

        public Enemy(string name, string lookDescription, float health)
        {
            Name = name;
            LookDescription = lookDescription;
            Health = health;
        }

        public void TakeDamage(float damageAmount)
        {
            _health -= damageAmount;
        }
        public override string ToString() => Name;

        private float _health;
    }
}
