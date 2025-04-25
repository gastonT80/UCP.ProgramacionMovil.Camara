using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CamaraScript : MonoBehaviour
{
    private bool camaraEnabled;
    private WebCamTexture backcam;
    private Texture deaultBackGround;

    public RawImage backgound;

    public AspectRatioFitter fit;

    // Start is called before the first frame update
    void Start()
    {
        deaultBackGround = backgound.texture;
        WebCamDevice[]devices=WebCamTexture.devices;

        if (devices.Length==0)
        {
            Debug.Log("no hay camara detectada");
            camaraEnabled = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++) 
        {
            if (!devices[i].isFrontFacing)
            {
                backcam = new WebCamTexture(devices[i].name,Screen.width,Screen.height);
            }
        }

        if (backcam == null)
        {
            Debug.Log("no se encuentra la camara trasera");
            return;
        }

        backcam.Play();
        backgound.texture = backcam;
        camaraEnabled=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!camaraEnabled)
        {
            return;
        }

        float ratio=(float)backcam.width/ (float)backcam.height;
        fit.aspectRatio = ratio;

        float scaleY= backcam.videoVerticallyMirrored ? -1f : 1f;
        backgound.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        float orient= -backcam.videoRotationAngle;
        backgound.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
