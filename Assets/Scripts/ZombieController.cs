

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieController : MonoBehaviour
{
    public Transform target;
    [SerializeField] float update_speed = 0.1f;
    NavMeshAgent Zombie;

    private void Awake()
    {
        Zombie = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(update_speed);
        while (enabled)
        {
            Zombie.SetDestination(target.transform.position);
            yield return Wait;
        }
    }

    public void moveZombie(Vector3 pos)
    {
        Zombie.Warp(pos);
    }
}
