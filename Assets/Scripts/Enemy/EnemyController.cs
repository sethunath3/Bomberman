using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Grid;

namespace BomberMan.Enemy
{
    public class EnemyController
    {
        private EnemyView view;
        public EnemyController(EnemyPropsSO _enemyProps, Vector2 _position)
        {
            view = GameObject.Instantiate(_enemyProps.enemyPrefab, _position, Quaternion.identity);
            view.Speed = _enemyProps.patrolingSpeed;
            view.SetController(this);
        }

        public void KillEnemy()
        {
            view.DestroyView();
            view = null;
        }

        public void ReDirect()
        {
            Vector2 newTarget = TilemapService.Instance.GetRandomAdjacentTarget(view.GetPosition());
            view.Target = newTarget;
        }
    }
}
