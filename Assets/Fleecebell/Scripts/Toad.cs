using UnityEngine;

public class Toad : MonoBehaviour
{
    private Animator anim;
    bool isOpen = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !isOpen)
        {
            anim.SetBool("toad_isOpen", true);
            isOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && isOpen)
        {
            anim.SetBool("toad_isOpen", false);
            isOpen = false;
        }
    }
}
