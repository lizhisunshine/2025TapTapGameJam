using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTigger : MonoBehaviour
{

    public int endNum;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerFather"))
        {
            if (other.GetComponent<ItemManager>().LightUpNum >= endNum)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
