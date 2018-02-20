﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    public bool endLevelOnColl = false;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            
            MovePlayer(coll.gameObject.GetComponent<PlayerMovement>());
        }
    }

    void MovePlayer(PlayerMovement player)
    {

        if (player.jumping)
            return;
        if (endLevelOnColl)
        {
            player.transform.position = new Vector2(0, -2.5f);
            CameraMovement.instance.transform.position = new Vector3(0,0, CameraMovement.instance.transform.position.z);


            player.min = -2.5f;
            player.max = player.min + 1;
            player.jumpHeight = -1.5f;
        }
        else
        {
            AudioManager.instance.PlaySound("PLStripOver");
            player.transform.position = new Vector2(0, player.transform.position.y - SpawnManager.instance.stripGapDistance);
            CameraMovement.instance.transform.position = new Vector3(CameraMovement.instance.transform.position.x, CameraMovement.instance.transform.position.y - SpawnManager.instance.stripGapDistance, CameraMovement.instance.transform.position.z);
            player.min -= SpawnManager.instance.stripGapDistance;
            player.max = player.min + 1;
            player.jumpHeight -= SpawnManager.instance.stripGapDistance;
        }
    }

}
