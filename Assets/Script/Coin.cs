using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinSfx;
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(coinSfx, transform.position);
        scoreManager.Addscore(10);
        Destroy(gameObject);
        
    }

 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(200f * Time.deltaTime * Vector3.forward);
    }
}
