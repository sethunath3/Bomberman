using UnityEngine;
using BomberMan.Interfaces;
using BomberMan.Gameplay;

namespace BomberMan.Player
{
    public class PlayerView : MonoBehaviour, IDamageable
    {
        private PlayerController controller;
        private float speed;
        public float Speed{ set{speed = value;}}
        public void Setcontroller(PlayerController _controller)
        {
            controller = _controller;

        }

        public void DestroyView()
        {
            Destroy(gameObject);
        }

        public void TakeDamage()
        {
            controller.KillPlayer();
        }

        public void ModifyTransform(float xOffset, float yOffset)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            Vector2 currentVelocity = rb.velocity;
            Vector2 newVelocity = new Vector2(xOffset * speed, yOffset * speed);
            

            rb.velocity = newVelocity;
        }

        public Vector2 GetPosition()
        {
            return gameObject.transform.position;
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.layer == (int)GameObjectLayers.ENEMY)
            {
                controller.KillPlayer();
            }
        }
    }
}

