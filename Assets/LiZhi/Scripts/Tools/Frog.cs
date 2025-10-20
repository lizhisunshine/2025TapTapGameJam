using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField]private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(Resources.Load("Torch"), new Vector3(0f, 0f, 0f), Quaternion.Euler(new Vector3(0, 0, 0f)));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
