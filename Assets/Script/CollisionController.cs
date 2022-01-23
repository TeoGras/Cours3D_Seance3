using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
/*
 * Classe attacher a tous les GameObject qui doivent être detruit par les balles
 */
{
    private static LayerMask bulletLayer;

    private void Awake() {
        bulletLayer = LayerMask.NameToLayer("Bullet");
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == bulletLayer)
        {
            Destroy(gameObject);
        }
    }
}
