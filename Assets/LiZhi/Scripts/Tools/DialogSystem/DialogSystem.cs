using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class DialogSystem:MonoBehaviour 
{
    //public GameObject player;
    [Header("对话框ui和对话框文本")]
    public GameObject dialogBox;
    public GameObject ContentText;

    [Header("玩家名ui和玩家名文本")]
    public GameObject playerNameUI;
    public GameObject playerNameText;

    [Header("物品名ui和物体名文本")]
    public GameObject objNameUI;
    public GameObject ObjNameText;

    [Header("打字间隔时间")]
    public float speedTime = 0.1f;//打字间隔时间
    public float timer;//计时器时间
    public int wordNumber;

    [Header("其它脚本用来调用本脚本的方法 需要修改的参数")]
    public string PlayerName;//玩家名
    public string ObjName;//物品名
    public string contant;//要说的内容
    public bool isPlayerTalk;//是否玩家说话
    public bool isStart;//打字机启动标记

    [Header("聊天最大距离")]
    public float maxDistance;
    //public GameObject lastAnimal; 

    [Header("音效")]
    public AudioSource TalkSource;
    public AudioClip TalkClip;

    public void Start()
    {
        //maxDistance = 10;
        //isStart = true;
        PlayerName = "艾可";
        ObjName = "小动物";
        contant = "你怎么才找到我啊我等你半天了你mlb的你怎么才找到我啊我等你半天了你mlb的";
        isPlayerTalk = false;

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TalkOver();
        }

        //|| Vector3.Distance(player.transform.transform.position, lastAnimal.transform.position) >= maxDistance

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //下面是从外部调用这个脚本方法需要传入的标准内容表。
        //    wordNumber = 0;
        //    PlayerName = "主角";
        //    ObjName = "小动物";
        //    contant = "我跟你说话你没听见啊";
        //    isPlayerTalk = true;
        //    isStart = true;
        //}

    }

    public void FixedUpdate()
    {
        if (isStart)
        { 
            Talk();
        }

    }

    public void Talk()
    {

        if (isPlayerTalk)
        { 
            //重置ui状态
            playerNameUI.SetActive(true);
            dialogBox.SetActive(true);
            objNameUI.SetActive(false);
            //重置文本状态
            //ContentText.GetComponent<TMP_Text>().text = content;
            playerNameText.GetComponent<TMP_Text>().text = PlayerName;

            if (isStart)
            {
                timer += Time.deltaTime;//简单的计时器
                if (timer >= speedTime)//如果计时器时间>打字间隔时间
                {
                    timer = 0;//重置
                    wordNumber++;//文字数量+1

                    TalkSource.PlayOneShot(TalkClip);

                    //Substring() 官方文档解释：从此实例检索子字符串。 子字符串从指定的字符位置开始且具有指定的长度。
                    ContentText.GetComponent<TMP_Text>().text = contant.Substring((0), wordNumber);
                    if (wordNumber >= contant.Length)//数字数量=文字的长度
                    {
                        isStart = false;//停止打字
                        contant = null;
                        wordNumber = 0;
                    }
                }
            }

        }
        else if (!isPlayerTalk)
        { 
            dialogBox.SetActive(true);
            objNameUI.SetActive(true);
            playerNameUI.SetActive(false);
            //ContentText.GetComponent<TMP_Text>().text = contant;
            ObjNameText.GetComponent<TMP_Text>().text = ObjName;

            if (isStart)
            {
                timer += Time.deltaTime;//简单的计时器
                if (timer >= speedTime)//如果计时器时间>打字间隔时间
                {
                    timer = 0;//重置
                    wordNumber++;//文字数量+1

                    TalkSource.PlayOneShot(TalkClip);

                    //Substring() 官方文档解释：从此实例检索子字符串。 子字符串从指定的字符位置开始且具有指定的长度。
                    ContentText.GetComponent<TMP_Text>().text = contant.Substring((0), wordNumber);
                    if (wordNumber >= contant.Length)//数字数量=文字的长度
                    {
                        isStart = false;//停止打字
                        contant = null;
                        wordNumber = 0;
                    }
                }
            }

        }
        
    }

    public void TalkOver()
    {
        dialogBox.SetActive(false);
        objNameUI.SetActive(false);
        playerNameUI.SetActive(false);
        //contant = null;
        //wordNumber = 0;

        isStart = false;
    }
}
