using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const int ZDEPTH = 150;

    [SerializeField] private GameObject sprayImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = ZDEPTH;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z += 10;
        transform.position = mousePos;

        if(Input.GetMouseButtonDown(0))
        {
            sprayImage.SetActive(true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            sprayImage.SetActive(false);
        }
    }
}
