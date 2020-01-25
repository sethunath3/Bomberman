using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;
using BomberMan.Player;
using BomberMan.Bomb;
using BomberMan.Grid;

namespace BomberMan.Gameplay
{
    public class GameplayManager : GenericMonoSingleton<GameplayManager>
    {
        [SerializeField]
        private PlayerView playerObjectView;
        private PlayerController playerController;

        private void Start()
        {
            if(playerObjectView == null)
            {
                Debug.LogError("player object not linked");
            }
            playerController = new PlayerController(playerObjectView);
            TilemapService.Instance.PopulateDestructableBlocks(25);
            TilemapService.Instance.PopuplateEnemies(5);
            
        }
        public void HandlePlayerInput(float xOffset, float yOffset)
        {
            playerController.MovePlayer(xOffset, yOffset);
        }
        public void PlaceBomb()
        {
            BombService.Instance.DropBombAt(playerController.GetPosition());
        } 

        public Vector2 GetPlayerPosition()
        {
            return playerController.GetPosition();
        }
    }
}
