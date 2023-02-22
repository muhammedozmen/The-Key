using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float damageRange;
    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;
    

    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioSource source;

    private FirstPersonMovement firstPersonMovement;
    
    void Start()
    {
        damageRange = Random.Range(minDamage, maxDamage);
        source = player.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().health -= damageRange;
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.Play();
        }
    }
}
