using UnityEngine;

public class Harvesting : MonoBehaviour
{
    public Tool HarvestingTool
    {
        get => _harvestingTool;
        set
        {
            if (_harvestingTool != value)
            {
                _harvestingTool = value;
                UpdateSprite();
            }
        }
    }

    [SerializeField] private Tool _harvestingTool;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (_harvestingTool != null)
        {
            _sr.sprite = _harvestingTool.Sprite;
        }
        else
        {
            _sr.sprite = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Harvestable harvestable))
        {
            harvestable.TryHarvest(HarvestingTool?.Type);
        }
    }
}
