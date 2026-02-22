using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具效果 使用ScriptableObject
/// </summary>
public abstract class ItemEffectBase : ScriptableObject, IItemEffect
{
    [Header("效果基础信息")]
    [SerializeField] protected string effectName = "效果";
    [SerializeField][TextArea] protected string effectDescription = "效果描述";

    [Header("视听效果")]
    [SerializeField] protected AudioClip effectSound;//音效
    public abstract bool Execute(GameObject user,GameObject obj);

    public virtual string GetDescription()
    {
        return effectDescription;
    }
    public virtual bool CanUse(GameObject user)
    {
        return true;
    }
}
