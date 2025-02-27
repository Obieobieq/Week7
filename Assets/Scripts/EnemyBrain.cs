using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField]
    private Transform[] points;

    private int pointNumber = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(points[pointNumber].transform.position);
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            _agent.SetDestination(other.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            pointNumber = (pointNumber + 1) % points.Length;
            _agent.SetDestination(points[pointNumber].transform.position);
        }
    }
}
