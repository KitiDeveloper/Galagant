using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float speed;

    [SerializeField] private Renderer bgRender;

    void FixedUpdate()
    {
        bgRender.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
