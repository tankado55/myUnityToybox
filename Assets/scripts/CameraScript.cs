using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform playerTransform;
    private int depth = -15;

    private void Start()
    {
        transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0, 10, depth);           
        }
    }

    public void setPlayerToFollow(Transform transform)
    {
        playerTransform = transform;
    }
}
