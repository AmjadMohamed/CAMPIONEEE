using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float BGSpeed = 0;
    public Renderer BGRenderer;

    private void Update()
    {
        BGRenderer.material.mainTextureOffset += new Vector2(BGSpeed * Time.deltaTime, 0);
    }
}
