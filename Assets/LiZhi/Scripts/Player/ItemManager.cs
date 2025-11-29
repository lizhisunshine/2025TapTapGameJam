using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //玩家
    public GameObject user;
    //玩家是否拿着东西
    public bool isPickSTH;
    //玩家手上拿的东西
    public GameObject item;
    //玩家拿物体的时候 物体的偏移
    public float deltaDistance;
    public Vector3 deltaVector3;

    //判断被使用物体是否打开
    public bool isOpen;

    //确定玩家是否死亡
    public bool isDead;
    //保存最后一个被打开的物品
    public GameObject LastObject;

    //目前能取得夜明珠的次数
    public int gitNum;

    public ItemEffectBase itemEffect;
    public ItemEffectBase lastEffect;

    //存储当前标记的篝火
    public GameObject Fire;
    //存储当前关卡能使用夜明珠的次数 这个次数是由当前关卡对应的篝火所决定的
    public int nowLevelNum;

    //存储玩家当前身上的钥匙
    public List<GameObject> Keys;
    //存储当前使用的门

    //存储所有的青蛙 判断青蛙动画状态
    public bool isHadPick;
    public List <Animator> FrogAnimations;

    //存储当前点燃的灯笼数量
    public int LightUpNum;

    //对话系统
    public DialogSystem dialogSystem;
    public GameObject LastAnimal;
    public float AnimalsDistance;

    //修复 卡关问题的参数
    public FrogEffext frogEffext;

    // Start is called before the first frame update
    void Start()
    {
        user = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickSTH)
        {
            //item.transform.position = user.transform.position+Vector3.up*deltaDistance;
            //查找 当这个球是玩家子物体的时候不进入下面的逻辑。
            if (item.gameObject.transform.parent != this.transform)
            {
                item.transform.position = this.gameObject.transform.Find("HoldPoint").transform.position;
                //将拿在玩家手中的物体设置为玩家子物体
                item.gameObject.transform.SetParent(this.transform);
                //取消手上物体的collider，并且取消使用重力
                item.GetComponent<Collider>().enabled = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.GetComponent<Rigidbody>().useGravity = false;
            }

        }
        //用于测试篝火是否生效的方法
        if (Input.GetKeyDown(KeyCode.R))
        {
            isDead = true;
        }
        if (isDead)
        {
            GameObject.Find("CenterPointController").GetComponent<DisslutionCenter1>().isShrink = true;
            user.GetComponent<ItemManager>().isPickSTH = false;
            frogEffext.isHadPick = false;
            isHadPick = false;
            Destroy(GameObject.Find("Sphere(Clone)"));

            gitNum = nowLevelNum;

            transform.position = Fire.transform.position+new Vector3(0,0.9f,2);
            isDead = false;
        }
        //根据玩家当前是否取出夜明珠 判断当前青蛙动画状态
        if (isHadPick)
        {
            for (int i = 0; i < FrogAnimations.Count; i++)
            {
                FrogAnimations[i].SetBool("isOpen", true);
                FrogAnimations[i].SetBool("isClose", false);

            }
        }
        else 
        {
            for (int i = 0; i < FrogAnimations.Count; i++)
            {
                FrogAnimations[i].SetBool("isOpen", false);
                FrogAnimations[i].SetBool("isClose", true);

            }
        }
        //当玩家没有了使用蟾蜍的机会，让玩家死亡并且重置当前次数
        //if (gitNum==0)
        //{
        //    isDead=true;
        //    //gitNum = nowLevelNum;
        //}
        //当玩家和上一次对话的动物的距离超出最大距离 结束对话
        if (LastAnimal != null)
        {
            AnimalsDistance = Vector3.Distance(this.gameObject.transform.position, LastAnimal.transform.position);
            if (AnimalsDistance >= dialogSystem.maxDistance)
            {
                Debug.Log("超出距离，结束对话。当前距离为："+ AnimalsDistance);
                dialogSystem.TalkOver();
            }
        } 

            
    }

}
