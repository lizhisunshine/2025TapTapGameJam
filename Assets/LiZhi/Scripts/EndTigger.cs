using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTigger : MonoBehaviour
{

    public int endNum;
    public GameObject player;
    public void Update()
    {
        endNum = player.GetComponent<ItemManager>().LightUpNum;

        if (endNum >= 6)
        {
            this.GetComponent<Light>().enabled = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {



        if (other.CompareTag("PlayerFather") && endNum>=6)
        {
            if (other.GetComponent<ItemManager>().LightUpNum >= endNum)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
