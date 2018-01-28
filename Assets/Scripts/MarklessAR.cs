using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarklessAR : MonoBehaviour {

    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rotation;

    //Cam
    private WebCamTexture cam;
    public RawImage background;
    public AspectRatioFitter fit;

    private bool arReady = false;
    


	// Use this for initialization
	void Start () {
        
        // Chenck if we supoprt both services
        // Gyro
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("This device does not have Gyroscope");
            return;
        }

        // Back camera
        for ( int i=0; i < WebCamTexture.devices.Length; i++)
        {
            if (!WebCamTexture.devices[i].isFrontFacing)
            {
                cam = new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
        }

        if(cam == null)
        {
            Debug.Log("This device does not have back Camera");
            return;
                        
        }

        // Both services are supported, let's enable them!
        cameraContainer = new GameObject("Camera Container");
        
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyro = Input.gyro;
        gyro.enabled = true;

        cameraContainer.transform.rotation = Quaternion.Euler(90f, 0, 0);
        rotation = new Quaternion(0, 0, 1, 0);

        cam.Play();
        background.texture = cam;

        arReady = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (arReady)
        {
            // update cam
            float ratio = (float)cam.width / (float)cam.height;
            fit.aspectRatio = ratio;

            float scaleY = cam.videoVerticallyMirrored ? -1.0f : 1.0f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orient = -cam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
            //update Gyro
            transform.localRotation = gyro.attitude * rotation;
        }
	}
}
