using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float xRotationOffset = 30.0f;
    public GameObject objectToFollow;

    private Vector3 relativePosition;
    private Quaternion relativeRotation;

    // Start is called before the first frame update
    void Start()
    {
        this.relativePosition = this.transform.position - this.objectToFollow.transform.position;
        this.relativeRotation = this.transform.rotation;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        /* Sorry I do not know how this works */
        var rotation = this.objectToFollow.transform.rotation * this.relativeRotation;
        var v = this.objectToFollow.transform.position + this.objectToFollow.transform.rotation * this.relativePosition;
        this.transform.position = v;
        this.transform.rotation = rotation;
    }
}
