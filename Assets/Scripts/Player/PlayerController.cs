using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Gameplay;

namespace BomberMan.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        public PlayerController(PlayerView _playerView, float runningSpeed)
        {
            playerView = _playerView;
            playerView.Speed = runningSpeed;
            playerView.Setcontroller(this);
        }

        public void MovePlayer(float xOffset, float yOffset)
        {
            playerView.ModifyTransform(xOffset, yOffset);
        }

        public Vector2 GetPosition()
        {
            return playerView.GetPosition();
        }

        public void KillPlayer()
        {
            playerView.DestroyView();
            playerView = null;
            GameplayManager.Instance.GameOver(false);
        }
    }
}
