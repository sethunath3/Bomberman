using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Interfaces;

namespace BomberMan.Enemy
{
    public class EnemyView : MonoBehaviour, IDamageable
    {
        private EnemyController controller;
        private float speed;
        public float Speed{set{speed = value;}}
        private Vector2 target;
        public Vector2 Target{ set{ target = value;}}

        private void Start()
        {
            target = gameObject.transform.position;
        }

        private void Update()
        {
            
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target, step);
            if(Vector2.Distance(gameObject.transform.position, target) <= 0.01f)
            {
                if(controller != null)
                {
                    controller.ReDirect();
                }
            } 
        }
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

        public Vector2 GetPosition()
        {
            return gameObject.transform.position;
        } 
    }
}
