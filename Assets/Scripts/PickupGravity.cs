using System.Collections.Generic;
using UnityEngine;

public class PickupGravity : MonoBehaviour
{
    [SerializeField] private float _gravitySpeed;
    private List<Pickable> _nearbyResources = new();

    private void FixedUpdate()
    {
        _nearbyResources.RemoveAll(pickup => pickup == null);

        foreach (var pickup in _nearbyResources)
        {
            Vector2 directionToCenter = 
                (transform.position - pickup.transform.position).normalized;
            pickup.transform.Translate(directionToCenter * _gravitySpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Pickable pickable))
        {
            _nearbyResources.Add(pickable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Pickable pickable))
        {
            _nearbyResources.Remove(pickable);
        }
    }
}
