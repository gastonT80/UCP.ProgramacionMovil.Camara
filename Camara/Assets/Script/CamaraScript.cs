using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamaraScript : MonoBehaviour
{
    private bool camaraEnabled;
    private WebCamTexture cam;
    private Texture Ground;

    private RawImage backgound;

    public AspectRatioFitter fitter;

    // Start is called before the first frame update
    void Start()
    {
        Ground = backgound.texture;
        WebCamDevice[]devices=WebCamTexture.devices;

        if (devices.Length==0)
        {
            Debug.Log("no hay camara detectada");
            camaraEnabled = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++) 
        { 
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
