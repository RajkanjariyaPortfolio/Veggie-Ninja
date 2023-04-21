using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Camera mainCam;
    TrailRenderer trail;

    [SerializeField] private AudioSource sliceSoundEffect;
    private void Awake() 
    {
        mainCam = Camera.main;
        trail = GetComponent<TrailRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            trail.emitting = true;
            sliceSoundEffect.Play();
        }
        
        if(Input.GetKey(KeyCode.Mouse0))
        {
            var newPos = transform.position;
            newPos.x = mainCam.ScreenToWorldPoint(Input.mousePosition).x;
            newPos.y = mainCam.ScreenToWorldPoint(Input.mousePosition).y;
            transform.position = newPos;
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            trail.emitting = false;
        }
       
    }
}
