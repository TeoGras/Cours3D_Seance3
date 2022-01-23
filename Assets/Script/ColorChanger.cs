using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private static LayerMask _bulletLayer;
    [SerializeField] private GameObject light;
    private int _colorChanger;
    private Light lt;

    private void Awake()
    {
        lt = light.GetComponent<Light>();
        _bulletLayer = LayerMask.NameToLayer("Bullet");
        _colorChanger = 0;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == _bulletLayer)
        {
            if (_colorChanger>2)
            {
                _colorChanger = 0;
            }
            else
            {
                _colorChanger += 1;
            }

            switch (_colorChanger)
            {
             case 0:
                 lt.color = Color.white;
                 break;
             case 1 :
                 lt.color = Color.yellow;
                 break;
             case 2 :
                 lt.color = Color.blue;
                 break;
             case 3 :
                 lt.color = Color.black;
                 break;
            }
        }
    }
    
}
