using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject player;
    [SerializeField] private float damageRange;
    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;

    public bool isAttacking;

    [SerializeField] private AudioSource PlayerAudioSource;
    [SerializeField] private AudioClip[] PlayerHurtSounds;
    
    [SerializeField] private AudioSource AttackAudioSource;
    [SerializeField] private AudioClip[] DevilAttackSounds;

  
    void Start()
    {
        isAttacking = false;
        damageRange = Random.Range(minDamage, maxDamage);
    }

    private void Update()
    {
        if (isAttacking)
        {
            animator.SetBool("isAttacking", true);
        }
        else if (isAttacking == false)
        {
            animator.SetBool("isAttacking", false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isAttacking = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAttacking = false;
        }
    }

    public void DamageDealt()
    {
        player.GetComponent<PlayerHealth>().health -= damageRange;
        PlayerAudioSource.clip = PlayerHurtSounds[Random.Range(0, PlayerHurtSounds.Length)];
        if(player.GetComponent<PlayerHealth>().health > 0)
        {
            PlayerAudioSource.Play();
        }   
    }

    public void AnimationEnter()
    {
        AttackAudioSource.clip = DevilAttackSounds[Random.Range(0, DevilAttackSounds.Length)];
        if (player.GetComponent<PlayerHealth>().health > 0)
        {
            AttackAudioSource.Play();
        }
    }
}
