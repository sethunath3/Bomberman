using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;
using BomberMan.Gameplay;

namespace BomberMan.Enemy
{
    public class EnemyService : GenericMonoSingleton<EnemyService>
    {
        [SerializeField]
        private  EnemyPropsSO enemyProps;
        
        private List<EnemyController> enemyList;

        public void InitEnemyService() {
            enemyList = new List<EnemyController>();
        }

        public void SpawnEnemyAt(Vector2 _position)
        {
            EnemyController enemy = new EnemyController(enemyProps, _position);
            enemyList.Add(enemy);
        }

        public void KillEnemy(EnemyController _enemy)
        {
            GameplayManager.Instance.EnemyKilled();
            enemyList.Remove(_enemy);
            _enemy.KillEnemy();
            if(enemyList.Count <= 0)
            {
                GameplayManager.Instance.GameOver(true);
            }
        }
    }
}