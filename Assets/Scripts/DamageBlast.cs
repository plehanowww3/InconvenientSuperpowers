using UnityEngine;

namespace DefaultNamespace
{
    public class DamageBlast: MonoBehaviour
    {
        public void CreateDamage(int _damage, float _radius)
        {
            Collider2D[] hittedColliders = Physics2D.OverlapCircleAll(transform.position, _radius);

            foreach (var collider in hittedColliders)
            {
                var health = collider.GetComponent<Health>();
                
                if (health)
                    health.TakeDamage(_damage);
            }
        }
    }
}