using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;
using BomberMan.Player;
using BomberMan.Bomb;
using BomberMan.Grid;
using BomberMan.UI;
using BomberMan.Enemy;
using BomberMan.Score;
using UnityEngine.Events;

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

        private UnityEvent ENEMY_KILLED;
        public UnityEvent ENEMY_KILLED_EVENT{get{ return ENEMY_KILLED;}}

        private void Start()
        {
            ENEMY_KILLED = new UnityEvent();
            
            if(playerObjectView == null)
            {
                Debug.LogError("player object not linked");
            }
            playerController = new PlayerController(playerObjectView, playerrunningSpeed);
            EnemyService.Instance.InitEnemyService();
            TilemapService.Instance.InitTilemapService();
            TilemapService.Instance.PopulateDestructableBlocks(25);
            TilemapService.Instance.PopuplateEnemies(5);
            ScoreManager.Instance.InitScoreManager();
            
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
            goCanvas.ShowGameOver(didPlayerWon, ScoreManager.Instance.GetScore());
        }

        public void EnemyKilled()
        {
            ENEMY_KILLED.Invoke();
        }
    }
}
