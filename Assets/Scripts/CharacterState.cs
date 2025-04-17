using UnityEngine;

[CreateAssetMenu(fileName = "CharacterState", 
    menuName = "Gatherer Top-Down RPG/CharacterState")]
public class CharacterState : ScriptableObject
{
    [field: SerializeField] public bool CanMove { get; private set; }
    [field: SerializeField] public bool CanExitWhilePlaying { get; private set; }
}
