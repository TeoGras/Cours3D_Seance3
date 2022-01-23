using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDispawner : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    
    public void Start() {
        StartCoroutine(Dispawn());
    }

    private IEnumerator Dispawn() {
        /*
         * Coroutine qui fait dispawn chaque balle après qu'elle est existée 5s
         */
        while (true) {
            yield return new WaitForSeconds(timer);
            Destroy(transform.gameObject);
        }
    }

}
