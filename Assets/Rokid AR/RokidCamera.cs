using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RokidCamera : MonoBehaviour
{
    [Header("移动配置")]
    public Camera targetCamera; // 拖拽相机赋值（推荐主相机）
    public float moveSpeed = 5f; // 移动速度（米/秒）
    [Tooltip("是否锁定Y轴位置（避免上下移动，比如贴地）")]
    public bool lockYPosition = true; // 默认锁定Y轴，适合地面移动
    public float yLockValue = 0f; // 锁定的Y轴高度（比如地面高度）

    // 缓存相机XZ平面的水平正前方和右方（避免重复计算）
    private Vector3 _cameraXZForward;
    private Vector3 _cameraXZRight;

    // 初始化：自动获取相机 + 验证配置
    private void Awake()
    {
        // 自动 fallback 主相机
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
            if (targetCamera == null)
            {
                Debug.LogError("场景中未找到相机！请添加带「MainCamera」标签的相机或手动赋值");
                enabled = false; // 禁用脚本避免报错
            }
        }
    }

    // 每帧更新输入和移动（Update处理输入，FixedUpdate更适合物理移动）
    private void Update()
    {
        if (targetCamera == null) return;

        // 1. 实时更新相机的XZ平面正前方和右方
        UpdateCameraXZDirections();

        // 2. 检测WASD输入，计算最终移动方向
        Vector3 moveDirection = CalculateMoveDirection();

        // 3. 执行移动（根据是否锁定Y轴调整）
        MoveObject(moveDirection);
    }

    // 更新相机XZ平面的正前方和右方（核心辅助方法）
    private void UpdateCameraXZDirections()
    {
        // 计算XZ平面正前方（原有逻辑优化）
        Vector3 originalForward = targetCamera.transform.forward;
        _cameraXZForward = new Vector3(originalForward.x, 0f, originalForward.z);
        if (_cameraXZForward.magnitude < 0.001f)
        {
            _cameraXZForward = Vector3.forward; // 相机垂直时默认Z轴正方向
        }
        _cameraXZForward.Normalize();

        // 计算XZ平面右方（相机右方向剔除Y轴，与正前方垂直）
        Vector3 originalRight = targetCamera.transform.right;
        _cameraXZRight = new Vector3(originalRight.x, 0f, originalRight.z);
        _cameraXZRight.Normalize();
    }

    // 根据WASD输入计算移动方向
    private Vector3 CalculateMoveDirection()
    {
        Vector3 direction = Vector3.zero;

        // W = 前（相机XZ正前方）
        if (Input.GetKey(KeyCode.W))
        {
            direction += _cameraXZForward;
        }
        // S = 后（相机XZ反方向）
        if (Input.GetKey(KeyCode.S))
        {
            direction -= _cameraXZForward;
        }
        // D = 右（相机XZ右方向）
        if (Input.GetKey(KeyCode.D))
        {
            direction += _cameraXZRight;
        }
        // A = 左（相机XZ反右方向）
        if (Input.GetKey(KeyCode.A))
        {
            direction -= _cameraXZRight;
        }

        // 归一化：避免斜向移动（W+D）时速度更快（保持移动速度一致）
        if (direction.magnitude > 0.001f)
        {
            direction.Normalize();
        }

        return direction;
    }

    // 执行物体移动（处理Y轴锁定）
    private void MoveObject(Vector3 moveDirection)
    {
        if (moveDirection.magnitude < 0.001f) return; // 无输入时不移动

        // 计算移动增量
        Vector3 moveDelta = moveDirection * moveSpeed * Time.deltaTime;

        // 锁定Y轴位置（保持固定高度）
        if (lockYPosition)
        {
            moveDelta.y = 0f; // 移动时不改变Y轴
            transform.position = new Vector3(transform.position.x, yLockValue, transform.position.z); // 强制锁定Y轴高度
        }

        // 移动物体
        transform.Translate(moveDelta);
    }

    // 可视化调试：Scene视图显示相机XZ方向（前=青色，右=红色）
    private void OnDrawGizmosSelected()
    {
        if (targetCamera == null) return;

        // 绘制XZ正前方（青色）
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + _cameraXZForward * 3f);
        Gizmos.DrawSphere(transform.position + _cameraXZForward * 3f, 0.15f);

        // 绘制XZ右方（红色）
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _cameraXZRight * 3f);
        Gizmos.DrawSphere(transform.position + _cameraXZRight * 3f, 0.15f);
    }
}