using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 100f * Time.deltaTime);
    }
}
