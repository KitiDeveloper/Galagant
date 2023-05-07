using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyGameObject", 7.5f);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
