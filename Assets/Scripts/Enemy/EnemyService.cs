using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;

namespace BomberMan.Enemy
{
    public class EnemyService : GenericMonoSingleton<EnemyService>
    {
        [SerializeField]
        private  EnemyView enemyPrefab;
        private List<EnemyController> enemyList;

        private void Start() {
            enemyList = new List<EnemyController>();
        }

        public void SpawnEnemyAt(Vector2 _position)
        {
            EnemyController enemy = new EnemyController(enemyPrefab, _position);
            enemyList.Add(enemy);
        }

        public void KillEnemy(EnemyController _enemy)
        {
            enemyList.Remove(_enemy);
            _enemy.KillEnemy();
        }
    }
}