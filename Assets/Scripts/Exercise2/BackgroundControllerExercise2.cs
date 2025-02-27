using System.Collections.Generic;
using UnityEngine;

public class BackgroundControllerExercise2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 1.0f;

    [SerializeField] private Renderer backgroundRenderer;

    private List<GameObject> backgrounds = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
