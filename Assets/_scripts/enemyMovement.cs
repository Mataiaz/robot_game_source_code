using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;

    public AudioSource audioss;
    // Start is called before the first frame update
    private bool hunting = false;
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(hunting) {
            if (!audioss.isPlaying)
                audioss.Play();
            if(player)
                enemy.SetDestination(player.transform.position);
        }
            
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            hunting = true;
            StartCoroutine(DestroyAfterCountdown(10f));
        }
    }

    IEnumerator DestroyAfterCountdown(float countdown)
    {
        yield return new WaitForSeconds(countdown);
        Destroy(gameObject);
    }
}
