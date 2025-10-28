using UnityEngine;
using UnityEngine.AI;

public class Insect : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    int i = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && i <= 3)
        {
            i++;
            Debug.Log(i);
        }
        if(i == 4)
        {
            i = 1;
            Debug.Log(i);
        }

        if (target1 != null && i == 1)
        {
            agent.SetDestination(target1.transform.position);
        }

        if(i == 2)
        {
            agent.SetDestination(target2.transform.position);
        }

        if(i == 3)
        {
            agent.SetDestination(target3.transform.position);
        }


    }
}