using UnityEngine;
using UnityEngine.AI;

public class Insect : MonoBehaviour
{
    public int i = 0;

    public GameObject L0_tar1;
    public GameObject L0_tar2;
    public GameObject L0_tar3;
    public GameObject L0_tar4;
    public GameObject L0_tar5;

    public GameObject L1_tar1;
    public GameObject L1_tar2;
    public GameObject L1_tar3;
    public GameObject L1_tar4;
    public GameObject L1_tar5;
    public GameObject L1_tar6;
    public GameObject L1_tar7;

    public GameObject L2_tar1;
    public GameObject L2_tar2;
    public GameObject L2_tar3;
    public GameObject L2_tar4;
    public GameObject L2_tar5;
    public GameObject L2_tar6;

    public GameObject L3_tar1;
    public GameObject L3_tar2;  
    public GameObject L3_tar3;
    public GameObject L3_tar4;
    public GameObject L3_tar5;
    public GameObject L3_tar6;

    public GameObject L4_tar1;
    public GameObject L4_tar2;
    public GameObject L4_tar3;
    public GameObject L4_tar4;
    public GameObject L4_tar5;
    public GameObject L4_tar6;

    public GameObject L5_tar1;
    public GameObject L5_tar2;
    public GameObject L5_tar3;
    public GameObject L5_tar4;
    public GameObject L5_tar5;
    public GameObject L5_tar6;
    public GameObject L5_tar7;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (L0_tar1 != null && i == 0)
        {
            agent.SetDestination(L0_tar1.transform.position);
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