using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : BaseTool
{
    public GameObject Player;
    public GameObject Player_hands;
    public override void Work()
    {
        this.transform.position = Player_hands.transform.position; 
    }

}
