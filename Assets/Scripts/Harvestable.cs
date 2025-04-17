using UnityEngine;

public class Harvestable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _resourceSpawnPS;
    [SerializeField] private GameObject _destroyedEffectPrefab;
    [SerializeField] private ToolType _toolType;
    [SerializeField] private int _resourceAmount = 5;
    [SerializeField] private int _minSpawnAmount = 1;
    [SerializeField] private int _maxSpawnAmount = 3;

    private int _harvestAmount = 0;

    public bool TryHarvest(ToolType type)
    {
        if (_toolType == type)
        {
            Harvest();
            return true;
        }

        return false;
    }

    private void Harvest()
    {
        int spawnAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount);
        int restAmount = _resourceAmount - _harvestAmount;

        if (spawnAmount < restAmount)
        {
            _resourceSpawnPS.Emit(spawnAmount);
            _harvestAmount += spawnAmount;
        }
        else
        {
            _resourceSpawnPS.Emit(restAmount);
            if (_destroyedEffectPrefab)
            {
                Instantiate(_destroyedEffectPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
