using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cart stone = collision.transform.root.GetComponent<Cart>();

        if (stone != null)
        {
            UILevelProgress.currentMomey += 1;
            Destroy(gameObject);
        }
    }
}
