using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private bool isFollow;
    [SerializeField] private GameObject player;
    public float speed;
    public Vector3 OffestVector;


    [Header("浮动设置")]
    public float floatHeight = 1.0f;     // 浮动高度
    public float floatSpeed = 1.0f;      // 浮动速度

    [Header("旋转设置")]
    public float rotateSpeed = 30.0f;    // 旋转速度（度/秒）
    public Vector3 rotateAxis = Vector3.up; // 旋转轴

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollow)
        {
            //让物体跟随玩家的方法
            transform.position = Vector3.Lerp(transform.position, player.transform.position + OffestVector, Time.deltaTime * speed);

            //让物体存储在道具管理器脚本里的方法
            if (player.GetComponent<ItemManager>().Keys.Exists(t => t == gameObject))
            { 
                return;
            }
            player.GetComponent<ItemManager>().Keys.Add(gameObject);
        }
        else 
        {
            // 上下浮动效果
            float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // 旋转效果
            transform.Rotate(rotateAxis * rotateSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerFather"))
        {
            if (!isFollow && this.GetComponent<AudioSource>() != null)
            {
                this.GetComponent<AudioSource>().Play();
            }
            Debug.Log("完成玩家绑定");
            isFollow = true;
            player = other.gameObject;

            //if (this.GetComponent<AudioSource>() != null)
            //{
            //    this.GetComponent<AudioSource>().Play();
            //}
        }
    }
}
