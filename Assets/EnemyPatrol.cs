using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    private int currentWaypointIndex = 0;
    private bool isWaiting = false;

    void Update()
    {
        if (!isWaiting)
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            StartCoroutine(PauseAtWaypoint());
        }
    }

    IEnumerator PauseAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(2);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        isWaiting = false;
    }
}
