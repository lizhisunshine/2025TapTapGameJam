using System.Linq;
using UnityEngine;

public class BLCollider : MonoBehaviour
{
    public DisslutionCenter1 dissolutionCenter1;//16
    public Rigidbody playerRb;

    public bool BCollider;
    public bool LCollider;
    public bool QCollider;

    public GameObject Biao0;
    public GameObject Biao1;
    public GameObject Biao2;
    public GameObject Biao3;
    public GameObject Biao4;
    //public GameObject Biao5;
    public GameObject Li0;
    public GameObject Li1;
    public GameObject Li2;
    public GameObject Li3;
    public GameObject Li4;
    //public GameObject Li5;

    public Collider[] BiaoCollider;
    public Collider[] LiCollider;

    public Transform player;
    public Transform ball;

    public float PlayerDis;
    public float R;

    Vector3 lastValidPosition;


    void Start()
    {
        lastValidPosition = player.transform.position;
        BCollider = false;
        LCollider = false;
        QCollider = false;

        //将Biao的所有带有Collider的子物体添加到BiaoCollider数组中
        foreach (Transform child1 in Biao0.transform)
        {
            if (child1.GetComponent<Collider>() != null)
            {
                BiaoCollider = BiaoCollider.Concat(new Collider[] { child1.GetComponent<Collider>() }).ToArray();
            }
        }
        foreach (Transform child1 in Biao1.transform)
        {
            if (child1.GetComponent<Collider>() != null)
            {
                BiaoCollider = BiaoCollider.Concat(new Collider[] { child1.GetComponent<Collider>() }).ToArray();
            }
        }
        foreach (Transform child1 in Biao2.transform)
        {
            if (child1.GetComponent<Collider>() != null)
            {
                BiaoCollider = BiaoCollider.Concat(new Collider[] { child1.GetComponent<Collider>() }).ToArray();
            }
        }
        foreach (Transform child1 in Biao3.transform)
        {
            if (child1.GetComponent<Collider>() != null)
            {
                BiaoCollider = BiaoCollider.Concat(new Collider[] { child1.GetComponent<Collider>() }).ToArray();
            }
        }
        foreach (Transform child1 in Biao4.transform)
        {
            if (child1.GetComponent<Collider>() != null)
            {
                BiaoCollider = BiaoCollider.Concat(new Collider[] { child1.GetComponent<Collider>() }).ToArray();
            }
        }
        //foreach (Transform child1 in Biao5.transform)
        //{
        //    if (child1.GetComponent<Collider>() != null)
        //    {
        //        BiaoCollider = BiaoCollider.Concat(new Collider[] { child1.GetComponent<Collider>() }).ToArray();
        //    }
        //}

        //将Li的所有带有Collider的子物体添加到LiCollider数组中
        foreach (Transform child2 in Li0.transform)
        {
            if (child2.GetComponent<Collider>() != null)
            {
                LiCollider = LiCollider.Concat(new Collider[] { child2.GetComponent<Collider>() }).ToArray();
            }
        }
        foreach (Transform child2 in Li1.transform)
        {
            if (child2.GetComponent<Collider>() != null)
            {
                LiCollider = LiCollider.Concat(new Collider[] { child2.GetComponent<Collider>() }).ToArray();
            }
        }
        foreach (Transform child2 in Li2.transform)
        {
            if (child2.GetComponent<Collider>() != null)
            {
                LiCollider = LiCollider.Concat(new Collider[] { child2.GetComponent<Collider>() }).ToArray();
            }
        }
        foreach (Transform child2 in Li3.transform)
        {
            if (child2.GetComponent<Collider>() != null)
            {
                LiCollider = LiCollider.Concat(new Collider[] { child2.GetComponent<Collider>() }).ToArray();
            }
        }
        foreach (Transform child2 in Li4.transform)
        {
            if (child2.GetComponent<Collider>() != null)
            {
                LiCollider = LiCollider.Concat(new Collider[] { child2.GetComponent<Collider>() }).ToArray();
            }
        }
        //foreach (Transform child2 in Li5.transform)
        //{
        //    if (child2.GetComponent<Collider>() != null)
        //    {
        //        LiCollider = LiCollider.Concat(new Collider[] { child2.GetComponent<Collider>() }).ToArray();
        //    }
        //}
    }

    void Update()
    {
        PlayerToBall();
        BLCol();
        QCol();

        Debug.Log(BCollider + " " + LCollider + " " + QCollider);
    }
    

    void PlayerToBall()
    {
        Vector3 positionA = player.transform.position;
        Vector3 positionB = ball.transform.position;
        PlayerDis = 2 * Vector3.Distance(positionA, positionB);
        R = dissolutionCenter1.distance;
    }
    void BLCol()
    {
        if (PlayerDis >= R && !BCollider && !LCollider)
        {
            Debug.Log("1");
            foreach (Collider col in BiaoCollider)
            {
                col.isTrigger = false;
            }
            foreach (Collider col in LiCollider)
            {
                col.isTrigger = true;
            }
        }
        else if (PlayerDis >= R && !BCollider && LCollider)
        {
            Debug.Log("2");
            foreach (Collider col in BiaoCollider)
            {
                col.isTrigger = false;
            }
            foreach (Collider col in LiCollider)
            {
                col.isTrigger = true;
            }
            if(QCollider)
            {
                lastPosition();
            }
        }
        if (PlayerDis < R && !BCollider && !LCollider)
        {
            Debug.Log("3");
            foreach (Collider col in BiaoCollider)
            {
                col.isTrigger = true;
            }
            foreach (Collider col in LiCollider)
            {
                col.isTrigger = false;
            }
        }
        else if (PlayerDis <= R && BCollider && !LCollider)
        {
            Debug.Log("4");
            foreach (Collider col in BiaoCollider)
            {
                col.isTrigger = true;
            }
            foreach (Collider col in LiCollider)
            {
                col.isTrigger = false;
            }
            if (QCollider)
            {
                lastPosition();
            }
        }
    }
    void QCol()
    {
        lastValidPosition = player.transform.position;
        if (PlayerDis > R - .5f && PlayerDis < R + .5f) 
        {
            QCollider = true;
        }
        else
        {
            QCollider = false;
        }
    }

    void lastPosition()
    {
        player.transform.position = lastValidPosition;
        Debug.Log("last position");
        //按w就往z轴反方向弹，按s就往z轴正方向弹，按a就往x轴方向弹，按d就往x轴反方向弹
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - .3f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + .3f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position = new Vector3(player.transform.position.x + .3f, player.transform.position.y, player.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position = new Vector3(player.transform.position.x - .3f, player.transform.position.y, player.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BCollider") BCollider = true;
        if (other.gameObject.tag == "LCollider") LCollider = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BCollider") BCollider = false;
        if (other.gameObject.tag == "LCollider") LCollider = false;
    }
}