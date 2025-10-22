using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleNavigationAgentController : MonoBehaviour
{   

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hit.point);
            }
        }
    } 
}