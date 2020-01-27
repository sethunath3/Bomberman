using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;

namespace BomberMan.Explosion
{
    public class ExplosionService : GenericMonoSingleton<ExplosionService>
    {
        [SerializeField]
        private ExplosionView explosionPrefab;
        public ExplosionView ExplosionPrefab{get { return explosionPrefab;}}
        [SerializeField]
        private float explosionAnimDuration;
        public void CreateExplosionAt(Vector2 _position)
        {
            ExplosionView explosion = ExplosionPool.Instance.GetItem();
            explosion.SetPosition(_position);
            explosion.SetEnabled(true);
            StartCoroutine(ReturnAfterDelay(explosion));
        }

        private IEnumerator ReturnAfterDelay(ExplosionView _explosion)
        {
            yield return new WaitForSeconds(explosionAnimDuration);
            _explosion.SetEnabled(false);
            ExplosionPool.Instance.ReturnItem(_explosion);
        }
    }
}
