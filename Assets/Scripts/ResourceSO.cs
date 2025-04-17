using UnityEngine;

[CreateAssetMenu(fileName = "ResourceSO", menuName = "Gatherer Top-Down RPG/ResourceSO")]
public class ResourceSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public float Value { get; private set; }
}
