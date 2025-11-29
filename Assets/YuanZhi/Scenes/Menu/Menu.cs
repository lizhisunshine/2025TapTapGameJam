using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 修正：去掉using和UnityEngine之间的点

public class Menu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
}