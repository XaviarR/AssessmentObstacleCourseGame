using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] GameObject[] checkPoint;
    public Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = gameObject.transform.position;//at start of game spawnpoint is made where player starts
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -20f)//if player is lower than -20f player respawns
        {
            gameObject.transform.position = spawnPoint;//player is moved to spawnpoint
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))//if player collides with tag CheckPoint
        {
            spawnPoint = other.gameObject.transform.position;//spawnpoint is set to checkPoint GameObject
            Destroy(other.gameObject);//previous spawnpoint is destroyed, so player can now spawn at new checkpoint
        }

        if (other.gameObject.CompareTag("Death"))//enemies
        {
            gameObject.transform.position = spawnPoint;//player is moved to spawnpoint
        }
    }
}
