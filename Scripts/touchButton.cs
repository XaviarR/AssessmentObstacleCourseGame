using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchButton : MonoBehaviour
{
    [SerializeField] GameObject bridge;

    private void Start()
    {
        bridge.SetActive(false);//bridge gameObject is now inactive
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))//collieds with Player
        {
            Debug.Log("button");
            bridge.SetActive(true);//bridge gameObject is now active
        }
    }
}
