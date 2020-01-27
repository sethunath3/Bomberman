using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;
using BomberMan.Grid;

namespace BomberMan.Bomb
{
    public class BombService : GenericMonoSingleton<BombService>
    {
        [SerializeField]
        private float bombCountDownTime;
        [SerializeField]
        private BombView bombPrefab;
        private BombView bombInstance;
        private float timer;

        public void DropBombAt(Vector3 position)
        {
            if(bombInstance == null)
            {
                timer = 0;
                bombInstance = GameObject.Instantiate<BombView>(bombPrefab, position, Quaternion.identity);
            }
        }

        private void Update()
        {
            if(bombInstance)
            {
                timer += Time.deltaTime;
                if(timer >= bombCountDownTime)
                {
                    Explode();
                }
            }
        }

        private void Explode()
        {
            TilemapService.Instance.ExplodedAt(bombInstance.GetPosition());
            bombInstance.DestroyBomb();
            bombInstance = null;
        }
    }
}
