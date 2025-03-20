

using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AgentController : Agent
{
    [SerializeField] float move_speed = 2f;
    Rigidbody rb;
    [SerializeField] GunController gunObject;
    bool can_shoot, hit_target, has_shot = false;
    int time_until_next_bullet = 0;
    int min_time_until_next_bullet = 30;
    [SerializeField] WorldBehaviors world_behaviors;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        world_behaviors.spawnAgent();
        world_behaviors.callSpawnZombie();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        can_shoot = false;

        float move_rotate = actions.ContinuousActions[0];
        float move_forward = actions.ContinuousActions[1];
        bool shoot = actions.DiscreteActions[0] > 0;

        rb.MovePosition(transform.position + transform.forward * move_forward * move_speed * Time.deltaTime);
        transform.Rotate(0f, move_rotate * move_speed, 0f, Space.Self);

        if (shoot && !has_shot)
        {
            can_shoot = true;
        }

        if (can_shoot)
        {
            hit_target = gunObject.shootGun();
            time_until_next_bullet = min_time_until_next_bullet;
            has_shot = true;

            if (hit_target)
            {
                AddReward(30);
                if (world_behaviors.getZombieCount() <= 0)
                {
                    EndEpisode(); // End episode when all zombies are killed
                }
            }
            else
            {
                AddReward(-1);
            }
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
        discreteActions[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            AddReward(-15f);
            EndEpisode(); // Keep this for wall collision
        }
        // Removed zombie collision end episode logic
        else if (other.gameObject.tag == "Zombie")
        {
            AddReward(-20f); // Negative reward for being caught by a zombie
            EndEpisode(); // End episode on zombie collision
        }
    }

    private void FixedUpdate()
    {
        if (has_shot == true)
        {
            time_until_next_bullet--;
            if (time_until_next_bullet <= 0)
            {
                has_shot = false;
            }
        }
    }
}
