using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;
using UnityEngine.UI;
using BomberMan.Gameplay;

namespace BomberMan.Score
{
    public class ScoreManager : GenericMonoSingleton<ScoreManager>
    {
        [SerializeField]
        private int scoreMultiplier;
        [SerializeField]
        private Text scoreCard;
        private int score;

        public void InitScoreManager()
        {
            score = 0;
            scoreCard.text = "Score: 0";
            GameplayManager.Instance.ENEMY_KILLED_EVENT.AddListener(EnemyKilled);
        }

        public int GetScore()
        {
            return score;
        }

        public void EnemyKilled()
        {
            score += scoreMultiplier;
            scoreCard.text = "Score: " + score;
        }
    }
}
