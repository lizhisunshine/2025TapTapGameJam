//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;
//using System.Text.RegularExpressions;

//public class DialogManager : MonoBehaviour
//{
//    /// <summary>
//    /// 控制对话是否激活的布尔变量
//    /// </summary>
//    public bool isDialogActive = false;

//    /// <summary>
//    /// 对话文本文件，csv格式
//    /// </summary>
//    public TextAsset dialogDataFile;

//    /// <summary>
//    /// 左侧角色图像
//    /// </summary>
//    public SpriteRenderer spriteLeft;
//    /// <summary>
//    /// 右侧角色图像
//    /// </summary>
//    public SpriteRenderer spriteRight;

//    /// <summary>
//    /// 角色名字文本
//    /// </summary>
//    public TMP_Text nameText;

//    /// <summary>
//    /// 对话内容文本
//    /// </summary>
//    public TMP_Text dialogText;

//    /// <summary>
//    /// 对话UI面板（需要添加这个引用）
//    /// </summary>
//    public GameObject dialogPanel;

//    /// <summary>
//    /// 角色图片列表
//    /// </summary>
//    public List<Sprite> sprites = new List<Sprite>();

//    /// <summary>
//    /// 角色名字对应图片的字典
//    /// </summary>
//    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();

//    /// <summary>
//    /// 当前的对话索引值
//    /// </summary>
//    public int dialogIndex;

//    /// <summary>
//    /// 对话文本，按行分割
//    /// </summary>
//    public string[] dialogRows;

//    /// <summary>
//    /// 对话继续按钮
//    /// </summary>
//    public Button nextButton;

//    /// <summary>
//    /// 选项按钮预制体
//    /// </summary>
//    public GameObject optionButton;

//    /// <summary>
//    /// 选项按钮父节点，用于自动排列
//    /// </summary>
//    public Transform buttonGroup;

//    [SerializeField]
//    public List<Person> people = new List<Person>();

//    // Start is called before the first frame update
//    private void Awake()
//    {
//        imageDic["小狐狸"] = sprites[0];
//        imageDic["羊毛"] = sprites[1];
//        Person person = new Person();
//        person.name = "小狐狸";
//        people.Add(person);
//        Person doctor = new Person();
//        doctor.name = "羊毛";
//        people.Add(doctor);
//    }

//    void Start()
//    {
//        ReadText(dialogDataFile);
//        // 开始时隐藏对话UI
//        if (dialogPanel != null)
//            dialogPanel.SetActive(false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // 可以在这里添加触发对话的检测逻辑
//        // 例如：if (Input.GetKeyDown(KeyCode.Space) && !isDialogActive)
//        // {
//             StartDialog();
//        // }
//    }

//    /// <summary>
//    /// 开始对话
//    /// </summary>
//    public void StartDialog()
//    {
//        if (!isDialogActive)
//        {
//            isDialogActive = true;
//            dialogIndex = 0; // 重置对话索引

//            // 显示对话UI
//            if (dialogPanel != null)
//                dialogPanel.SetActive(true);

//            // 禁用其他操作（需要您根据具体游戏逻辑实现）
//            DisableOtherOperations();

//            // 开始显示对话
//            ShowDialogRow();
//        }
//    }

//    /// <summary>
//    /// 结束对话
//    /// </summary>
//    public void EndDialog()
//    {
//        isDialogActive = false;

//        // 隐藏对话UI
//        if (dialogPanel != null)
//            dialogPanel.SetActive(false);

//        // 启用其他操作（需要您根据具体游戏逻辑实现）
//        EnableOtherOperations();

//        // 清理选项按钮
//        ClearOptionButtons();
//    }

//    /// <summary>
//    /// 更新文本信息
//    /// </summary>
//    /// <param name="_name">角色名字</param>
//    /// <param name="_text">对话内容</param>
//    public void UpdateText(string _name, string _text)
//    {
//        nameText.text = _name;
//        dialogText.text = _text;
//    }

//    /// <summary>
//    /// 更新图片信息
//    /// </summary>
//    /// <param name="_name">角色名字</param>
//    /// <param name="_atLeft">是否出现在左侧</param>
//    public void UpdateImage(string _name, string _position)
//    {
//        if (_position == "左")
//        {
//            spriteLeft.sprite = imageDic[_name];
//        }
//        else if (_position == "右")
//        {
//            spriteRight.sprite = imageDic[_name];
//        }
//    }

//    public void ReadText(TextAsset _textAsset)
//    {
//        dialogRows = _textAsset.text.Split('\n');
//        Debug.Log("读取成功");
//    }

//    public void ShowDialogRow()
//    {
//        if (!isDialogActive) return;

//        for (int i = 0; i < dialogRows.Length; i++)
//        {
//            string[] cells = dialogRows[i].Split(',');
//            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
//            {
//                UpdateText(cells[2], cells[4]);
//                UpdateImage(cells[2], cells[3]);

//                dialogIndex = int.Parse(cells[5]);
//                nextButton.gameObject.SetActive(true);
//                break;
//            }
//            else if (cells[0] == "&" && int.Parse(cells[1]) == dialogIndex)
//            {
//                nextButton.gameObject.SetActive(false);
//                GenerateOption(i);
//            }
//            else if (cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
//            {
//                Debug.Log("剧情结束");
//                Debug.Log(people);
//                // 对话结束时调用EndDialog
//                EndDialog();
//            }
//        }
//    }

//    public void OnClickNext()
//    {
//        if (isDialogActive)
//        {
//            ShowDialogRow();
//        }
//    }

//    public void GenerateOption(int _index)
//    {
//        string[] cells = dialogRows[_index].Split(',');
//        if (cells[0] == "&")
//        {
//            GameObject button = Instantiate(optionButton, buttonGroup);
//            // 绑定按钮事件
//            button.GetComponentInChildren<TMP_Text>().text = cells[4];
//            button.GetComponent<Button>().onClick.AddListener
//                (
//                    delegate
//                    {
//                        if (cells[6] != "")
//                        {
//                            Debug.Log("添加按钮附加效果");
//                            string[] effect = cells[6].Split('@');

//                            cells[7] = Regex.Replace(cells[7], @"[\r\n]", "");
//                            //OptionEffect(effect[0], int.Parse(effect[1]), cells[7]);
//                        }
//                        OnOptionClick(int.Parse(cells[5]));
//                    }
//                );
//            GenerateOption(_index + 1);
//        }
//    }

//    public void OnOptionClick(int _id)
//    {
//        dialogIndex = _id;
//        ShowDialogRow();
//        ClearOptionButtons();
//    }

//    /// <summary>
//    /// 清理选项按钮
//    /// </summary>
//    private void ClearOptionButtons()
//    {
//        for (int i = 0; i < buttonGroup.childCount; i++)
//        {
//            Destroy(buttonGroup.GetChild(i).gameObject);
//        }
//    }

//    /// <summary>
//    /// 禁用其他操作（需要您根据具体游戏实现）
//    /// </summary>
//    private void DisableOtherOperations()
//    {
//        // 示例：暂停玩家移动
//        // if (playerController != null) 
//        //     playerController.enabled = false;

//        // 示例：暂停游戏时间
//        // Time.timeScale = 0f;

//        Debug.Log("禁用其他操作");
//    }

//    /// <summary>
//    /// 启用其他操作（需要您根据具体游戏实现）
//    /// </summary>
//    private void EnableOtherOperations()
//    {
//        // 示例：恢复玩家移动
//        // if (playerController != null) 
//        //     playerController.enabled = true;

//        // 示例：恢复游戏时间
//        // Time.timeScale = 1f;

//        Debug.Log("启用其他操作");
//    }

//    // 原有的OptionEffect方法保持不变...
//}
