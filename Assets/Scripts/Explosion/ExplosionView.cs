using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Interfaces;

namespace BomberMan.Explosion
{
    public class ExplosionView : MonoBehaviour
    {
        public void DestroyView(float delay)
        {
            Destroy(gameObject, delay);
        }

        public void SetEnabled(bool isEnabled)
        {
            gameObject.SetActive(isEnabled);
        }

        public void SetPosition(Vector2 position)
        {
            gameObject.transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            IDamageable damageablecomponent = other.gameObject.GetComponent<IDamageable>();
            damageablecomponent.TakeDamage();
        }
    }
}
