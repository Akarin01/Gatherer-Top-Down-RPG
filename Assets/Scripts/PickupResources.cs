using UnityEngine;

public class PickupResources : MonoBehaviour
{
    [field: SerializeField] public Inventory ResourcesInventory { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Pickable pickup))
        {
            ResourcesInventory.AddResources(pickup.ResourceType, 1);
            Destroy(pickup.gameObject);
        }
    }
}
