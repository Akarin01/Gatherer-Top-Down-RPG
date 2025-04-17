using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DirectionalAnimationSet",
    menuName = "Gatherer Top-Down RPG/DirectionalAnimationSet")]
public class DirectionalAnimationSet : ScriptableObject
{
    [field: SerializeField] public AnimationClip Up { get; private set; }
    [field: SerializeField] public AnimationClip Down { get; private set; }
    [field: SerializeField] public AnimationClip Left { get; private set; }
    [field: SerializeField] public AnimationClip Right { get; private set; }

    /// <summary>
    /// 根据输入的 facingDirection，返回对应方向的 AnimationClip
    /// </summary>
    /// <param name="facingDirection"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">closestDirection 无效</exception>
    public AnimationClip GetFaingClip(Vector2 facingDirection)
    {
        // 获得离 facingDirection 最近的方向向量
        Vector2 closestDirection = GetClosestDirection(facingDirection);

        // 返回该方向向量对应的 AnimationClip
        if (closestDirection == Vector2.up)
        {
            return Up;
        }
        else if (closestDirection == Vector2.down)
        {
            return Down;
        }
        else if (closestDirection == Vector2.left)
        {
            return Left;
        }
        else if (closestDirection == Vector2.right)
        {
            return Right;
        }
        else
        {
            throw new ArgumentException($"Direction not expected { facingDirection }"); 
        }
    }

    /// <summary>
    /// 根据输入的 inputDirection，返回 directions 数组中离它最近的向量
    /// </summary>
    /// <param name="inputDirection"></param>
    /// <returns>最近的向量</returns>
    public Vector2 GetClosestDirection(Vector2 inputDirection)
    {
        Vector2 normalizedDirection = inputDirection.normalized;

        Vector2 closestDirection = Vector2.zero;
        float closestDistance = -10f;

        Vector2[] directions = new Vector2[]
        {
            Vector2.up, Vector2.down, Vector2.left, Vector2.right,
        };

        for (int i = 0; i < directions.Length; i++)
        {
            float distance = Vector2.Dot(inputDirection, directions[i]);
            if (distance > closestDistance)
            {
                closestDirection = directions[i];
                closestDistance = distance;
            }
        }

        return closestDirection;
    }
}
