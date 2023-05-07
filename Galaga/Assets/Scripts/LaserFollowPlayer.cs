using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFollowPlayer : MonoBehaviour
{
    private GameObject playerShip;

    void Start()
    {
        playerShip = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerShip.transform.position;
    }
}
