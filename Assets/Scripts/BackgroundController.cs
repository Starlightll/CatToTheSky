using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    //private float startPos, length;
    //public GameObject cam;
    //public float parallaxEffect;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //startPos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
        float background1Length = background1.GetComponent<SpriteRenderer>().bounds.size.x;
        float background2Length = background2.GetComponent<SpriteRenderer>().bounds.size.x;
        float background3Length = background3.GetComponent<SpriteRenderer>().bounds.size.x;

        float cameraLeftEdgePosition = mainCamera.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;

        Debug.Log("CameraLeftEdge: " + cameraLeftEdgePosition);
        background2.transform.position = new Vector3(background1.transform.position.x + background1Length, background2.transform.position.y, background2.transform.position.z);
        background3.transform.position = new Vector3(background1.transform.position.x - background1Length, background3.transform.position.y, background3.transform.position.z);

        
        //if(cameraLeftEdgePosition > ((background1.transform.position.x - background1Length/2) || (background2.transform.position.x - background1Length / 2) || (background3.transform.position.x - background1Length / 2)))
        //{
        //    background1.transform.position = new Vector3(background3.transform.position.x - background3Length, background1.transform.position.y, background1.transform.position.z);
        //}
        //else if (cameraLeftEdgePosition > background2.transform.position.x)
        //{
        //    background1.transform.position = new Vector3(background2.transform.position.x + background2Length, background1.transform.position.y, background1.transform.position.z);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("Length: " + length);

        //float dist = (cam.transform.position.x * parallaxEffect);
        //float temp = (cam.transform.position.x * (1 - parallaxEffect));

        //transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        //if (temp > startPos + length) startPos += length;
        //else if (temp < startPos - length) startPos -= length;


    }
}
