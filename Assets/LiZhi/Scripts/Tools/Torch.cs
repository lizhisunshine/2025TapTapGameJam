using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : BaseTool
{
    public GameObject Player;
    public override void Work()
    {
        this.transform.position = Player.transform.position + Vector3.up * 3; 
    }

}
