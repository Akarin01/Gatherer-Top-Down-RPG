using System;
using UnityEngine;

[Serializable]
public class StateAnimationSetDictionary : SerializableDictionary<CharacterState, DirectionalAnimationSet>
{
    /// <summary>
    /// 根据 state 和 facingDirection，返回对应的 AnimationClip 
    /// </summary>
    /// <param name="state"></param>
    /// <param name="facingDirection"></param>
    /// <returns></returns>
    public AnimationClip GetFacingClipFromState(CharacterState state, Vector2 facingDirection)
    {
        if (TryGetValue(state, out DirectionalAnimationSet animationSet))
        {
            return animationSet.GetFaingClip(facingDirection);
        }
        Debug.LogError($"State {state} is not found in the StateAnimation Directionary!");
        return null;
    }
}
