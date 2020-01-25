using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberMan.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        public PlayerController(PlayerView _playerView)
        {
            playerView = _playerView;
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
    }
}
