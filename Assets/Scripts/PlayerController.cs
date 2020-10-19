using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _hat;
    [SerializeField] private GameObject _gravityGun;
    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is not attached to " + gameObject.name);
        }
    }

    void Update()
    {
        MouseClickMovement();
    }

    private void MouseClickMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                _navMeshAgent.destination = hit.point;
            }
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 5;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
