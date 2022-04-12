using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraFollowPlayer : NetworkBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            Camera.main.GetComponent<CameraScript>().setPlayerToFollow(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
