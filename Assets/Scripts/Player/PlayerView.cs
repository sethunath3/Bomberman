using UnityEngine;
using BomberMan.Interfaces;

namespace BomberMan.Player
{
    public class PlayerView : MonoBehaviour, IDamageable
    {
        private PlayerController controller;
        private float speed;
        public void Setcontroller(PlayerController _controller)
        {
            controller = _controller;

            speed = 2.0f;
        }

        public void TakeDamage()
        {
            //player died...game over
        }

        public void ModifyTransform(float xOffset, float yOffset)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            Vector2 currentVelocity = rb.velocity;
            Vector2 newVelocity = new Vector2(xOffset,yOffset);
            

            rb.velocity = newVelocity;
        }

        public Vector2 GetPosition()
        {
            return gameObject.transform.position;
        }
    }
}

