using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : MonoBehaviour
{
    [field: SerializeField] public Tool Tool { get; set; }

    private Harvesting _targetHarvesting;

    private void Awake()
    {
        _targetHarvesting = 
            FindAnyObjectByType<PlayerController>().GetComponentInChildren<Harvesting>();
    }

    public void ChangeTool()
    {
        if (_targetHarvesting != null)
        {
            _targetHarvesting.HarvestingTool = Tool;
            Debug.Log("Equip: " + Tool?.Name);
        }
        else
        {
            Debug.LogWarning("Can't find player!");
        }
    }
}
