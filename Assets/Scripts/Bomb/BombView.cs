using UnityEngine;

namespace BomberMan.Bomb
{
    public class BombView : MonoBehaviour
    {
        public void DestroyBomb()
        {
            Destroy(gameObject);
        }

        public Vector2 GetPosition()
        {
            return gameObject.transform.position;
        }
    }
}
