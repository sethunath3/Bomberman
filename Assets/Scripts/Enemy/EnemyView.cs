using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Interfaces;

namespace BomberMan.Enemy
{
    public class EnemyView : MonoBehaviour, IDamageable
    {
        private EnemyController controller;
        public void SetController(EnemyController _controller)
        {
            controller = _controller;
        }
        public void TakeDamage()
        {
            EnemyService.Instance.KillEnemy(controller);
        }

        public void DestroyView()
        {
            Destroy(gameObject);
        }
    }
}
