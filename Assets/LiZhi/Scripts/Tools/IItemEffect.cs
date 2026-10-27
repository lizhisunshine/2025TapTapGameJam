using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 道具效果接口 所有道具效果都需要实现此接口
/// </summary>
public interface IItemEffect 
{
    /// <summary>
    /// 执行效果
    /// </summary>
    /// <param name="user">使用者（通常为玩家）</param>
    /// <returns>是否成功执行</returns>
    bool Execute(GameObject user,GameObject obj);

    /// <summary>
    /// 获取效果描述（用于ui显示）
    /// </summary>
    string GetDescription();

    /// <summary>
    /// 判断道具是否可用
    /// </summary>
    bool CanUse(GameObject user);
}
