using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BomberMan.UI
{
    public class GameOverCanvas : MonoBehaviour
    {
        [SerializeField]
        private Text scoreValue;
        [SerializeField]
        private Text resulTtext;
        [SerializeField]
        private Button restartBtn; 

        private void Start() {
            if(restartBtn)
            {
                restartBtn.onClick.AddListener(OnReplayClicked);
            }
        }

        public void ShowGameOver(bool didPlayerWon, int score)
        {
            if(didPlayerWon)
            {
                resulTtext.text = "YOU WON";
            }
            else{
                resulTtext.text = "YOU LOST";
            }
            scoreValue.text = "Score: " + score; 
        }

        private void OnReplayClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
