using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    public GameObject player;
    public E_PlayerState currentState;
    //需要显示的图片
    public GameObject idleImages; 
    public GameObject walkImage;
    public GameObject RunImage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentState = player.GetComponent<PlayerController>().P.CurrentEState;

        if (idleImages && walkImage && RunImage)
        {
            switch (currentState)
            {
                case E_PlayerState.Idle:
                    idleImages.SetActive(true);
                    walkImage.SetActive(false);
                    RunImage.SetActive(false);
                    break;
                case E_PlayerState.Walk:
                    idleImages.SetActive(false);
                    walkImage.SetActive(true);
                    RunImage.SetActive(false);
                    break;
                case E_PlayerState.Run:
                    idleImages.SetActive(false);
                    walkImage.SetActive(false);
                    RunImage.SetActive(true);
                    break;
            }
        }

    }
}
