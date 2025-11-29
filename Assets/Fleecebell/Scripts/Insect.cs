using UnityEngine;
using UnityEngine.AI;

public class Insect : MonoBehaviour
{
    public int i = 0;
    public bool inTarget = false;

    public GameObject[] target;
    private NavMeshAgent agent;

    public bool isLightOn;//判断某位置灯笼是否被点亮

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target[i].transform.position);

        if (Input.GetKeyDown(KeyCode.C)) i++;
        Debug.Log("i="+i);

        if (i > target.Length) return;

        if (isLightOn)
        {
            i++;
            isLightOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((i == 4 || i == 11 || i == 17 || i == 23 || i == 29 || i == 36)&&!isLightOn)
        { 
            //当飞虫处于特定位置时，让它不能再继续前进
            return;
        }
        else if (other.gameObject.tag == "PlayerFather" && inTarget)
        {
            i++;
            //isLightOn = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Target") inTarget = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Target") inTarget = false;
    }
}