using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SerializableDictionary<ResourceSO, int> _resources;

    public int GetResourceCount(ResourceSO type)
    {
        if (_resources.TryGetValue(type, out int count))
        {
            return count;
        }
        return -1;
    }

    public int AddResources(ResourceSO type, int count)
    {
        if (_resources.TryGetValue(type, out _))
        {
            _resources[type] += count;
        }
        else
        {
            _resources.Add(type, count);
        }

        return _resources[type];
    }
}
