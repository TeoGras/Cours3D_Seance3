using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetController : MonoBehaviour
{
    [SerializeField] private float timerPosition = 3f;
    private Rigidbody puppetBody;
    [SerializeField] private float speedModifier = 0.01f;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
        puppetBody = GetComponent<Rigidbody>();
        StartCoroutine(ChangePosition());
    }

    private IEnumerator ChangePosition() {
        /*
         * Coroutine qui permet le mouvement des marionnettes
         */
        while (true)
        {
            float timer = 0f;
            Vector3 deltaPosition = RandomMovement();
            
            //On fait en sorte que le mouvement précedement calculer ce fasse pendant une certaine durer pour éviter
            //un effet bizzare a l'écran
            while (timer < timerPosition) {
                timer += Time.deltaTime;
                puppetBody.position += deltaPosition;
                
                //Si la marionnette est trop loin, on reset sa position
                if (Mathf.Abs(transform.position.x-originalPosition.x)>8f ||
                    Mathf.Abs(transform.position.z-originalPosition.z)>8f)
                {
                    ResetPosition();
                }
                //Si la marionnette est trop bas, on la fait remonter
                if (transform.position.y<1)
                {
                    transform.position += new Vector3(0f, 0.5f, 0f);
                }
                yield return new WaitForEndOfFrame(); //sinon unity crash
            }
        }
    }

    private Vector3 RandomMovement()
    {
        /*
         * Fonction qui permet d'optenir le déplacement d'une marionnette
         * @return Vector3 qui correspond au mouvement de la marionnette
         */
        return new Vector3(Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)) * speedModifier;
    }

    private void ResetPosition()
    {
        /*
         * Fonction qui permet de reset la position de la marionnette a sa position d'origine
         */
        transform.position = originalPosition;
    }
}
