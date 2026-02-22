using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsBase : MonoBehaviour
{
    public int TalkNum;

    public bool isTalkOver;

    public virtual void Talk() { }
    // Start is called before the first frame update
    public virtual void TalkOver() { }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
