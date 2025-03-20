

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform spawn_point;
    [SerializeField] LineRenderer laser_line;
    [SerializeField] float laser_duration = 0.05f;
    [SerializeField] float laser_range = 600f;
    [SerializeField] private WorldBehaviors worldBehaviors; // Reference to WorldBehaviors script

    public bool shootGun()
    {
        if (Physics.Raycast(spawn_point.position, transform.forward, out RaycastHit hit, laser_range))
        {
            laser_line.enabled = true;
            laser_line.SetPosition(0, spawn_point.position);
            laser_line.SetPosition(1, hit.point);

            if (hit.transform.gameObject.tag == "Zombie")
            {
                StartCoroutine(ShootLaser());
                Destroy(hit.transform.gameObject);
                worldBehaviors.spawnedZombieList.Remove(hit.transform.GetComponent<ZombieController>()); // Remove zombie from list
                return true;
            }
            else if (hit.collider.gameObject.tag == "Wall")
            {
                StartCoroutine(ShootLaser());
                return false;
            }
        }

        StartCoroutine(ShootLaser());
        return false;
    }

    private IEnumerator ShootLaser()
    {
        yield return new WaitForSeconds(laser_duration);
        laser_line.enabled = false;
    }
}