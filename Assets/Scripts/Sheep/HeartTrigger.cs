using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTrigger : MonoBehaviour
{
    public GameObject barnOutside = null;
    public GameObject canvasObject;

    // Start is called before the first frame update
    public Renderer object_render;
    void Start()
    {
        object_render = GetComponent<Renderer>();
        object_render.enabled = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            object_render.enabled = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            object_render.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
