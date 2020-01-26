using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;
using BomberMan.Player;
using BomberMan.Bomb;
using BomberMan.Grid;
using BomberMan.UI;
using BomberMan.Enemy;

namespace BomberMan.Gameplay
{
    public enum GameObjectLayers
    {
        PLAYER = 9,
        ENEMY = 10
    }

    public class GameplayManager : GenericMonoSingleton<GameplayManager>
    {
        [SerializeField]
        private PlayerView playerObjectView;
        [SerializeField]
        private float playerrunningSpeed;
        [SerializeField]
        private GameOverCanvas gameOverPopup;
        private PlayerController playerController;

        private void Start()
        {
            if(playerObjectView == null)
            {
                Debug.LogError("player object not linked");
            }
            playerController = new PlayerController(playerObjectView, playerrunningSpeed);
            EnemyService.Instance.InitEnemyService();
            TilemapService.Instance.InitTilemapService();
            TilemapService.Instance.PopulateDestructableBlocks(25);
            TilemapService.Instance.PopuplateEnemies(5);
            
        }
        public void HandlePlayerInput(float xOffset, float yOffset)
        {
            if(playerController != null)
            {
                playerController.MovePlayer(xOffset, yOffset);
            }
        }
        public void PlaceBomb()
        {
            if(playerController != null)
            {
                BombService.Instance.DropBombAt(playerController.GetPosition());
            }
        } 

        public Vector2 GetPlayerPosition()
        {
            return playerController.GetPosition();
        }

        public void GameOver(bool didPlayerWon)
        {
            playerController = null;
            GameOverCanvas goCanvas = Instantiate(gameOverPopup);
            goCanvas.ShowGameOver(didPlayerWon, 40);
        }
    }
}
