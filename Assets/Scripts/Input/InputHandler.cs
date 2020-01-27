using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Gameplay;

namespace BomberMan.InputHandle
{
    public class InputHandler : MonoBehaviour
    {
        void Update()
        {
            float inputX;
            float inputY;

            #if UNITY_EDITOR

            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
            if(inputX != 0 || inputY != 0)
            {
                GameplayManager.Instance.HandlePlayerInput(inputX, inputY);
            }
            if(Input.GetKeyUp(KeyCode.Space))
            {
                GameplayManager.Instance.PlaceBomb();
            }

            #endif
        }
    }
}
