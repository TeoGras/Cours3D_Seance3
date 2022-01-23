using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject puppetHolder;
    [SerializeField] private GameObject puppetPrefab;

    [SerializeField] private GameObject spawnZone;
    private Vector3 _origin;
    private Vector3 _range;
    [SerializeField] private float spawnSpeed = 1f;

    private void Awake() {
        _origin = spawnZone.transform.position;
        _range = spawnZone.transform.localScale / 2.0f;
    }

    public void Start() {
        StartCoroutine(DoSpawns());
    }

    private IEnumerator DoSpawns() {
        /*
         * Coroutine qui fait spawn une marionnette toute les 2/spawnSpeed seconde
         */
        while (true) {
            yield return new WaitForSeconds(2f / spawnSpeed);
            Instantiate(puppetPrefab, RandomSpawnPosition(), RandomRotation(), puppetHolder.transform);
        }
    }

    private Vector3 RandomSpawnPosition() {
        /*
         * Fonction qui permet de savoir a quel position faire spawner une marionnette
         * @return un Vecteur3 qui correspond a la position de spawn
         */
        return _origin + new Vector3(
            Random.Range(-_range.x, _range.x),
            Random.Range(-_range.y, _range.y),
            Random.Range(-_range.z, _range.z));
    }

    private static Quaternion RandomRotation() {
        /*
         * Fonction qui permet de savoir quel angle donner a la marionnette lors de son spawn
         * @return un Quaternion qui correspond a l'angle de rotation de la marionnette
         */
        return Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }
}
