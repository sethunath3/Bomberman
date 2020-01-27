using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberMan.Enemy
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/EnemyScriptableObject")]
    public class EnemyPropsSO : ScriptableObject
    {
        public EnemyView enemyPrefab;
        public float patrolingSpeed;
    }
}
