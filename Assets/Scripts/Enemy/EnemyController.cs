using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberMan.Enemy
{
    public class EnemyController
    {
        private EnemyView view;
        public EnemyController(EnemyView _enemyPrefab, Vector2 _position)
        {
            view = GameObject.Instantiate(_enemyPrefab, _position, Quaternion.identity);
            view.SetController(this);
        }

        public void KillEnemy()
        {
            view.DestroyView();
            view = null;
        }
    }
}
