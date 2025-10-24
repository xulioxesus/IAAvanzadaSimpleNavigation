using UnityEngine;
using UnityEngine.InputSystem;

// Clase simple para mover un NavMeshAgent ao punto onde o usuario fai clic co rato.
// - Emprega o Input System (Mouse.current) para detectar clics do botón esquerdo.
// - Lanza un Ray desde a cámara principal cara á posición do cursor.
// - Se o Ray acerta nun collider, establece o destino do axente co punto de impacto.
// Nota: non se comproba explicitamente se Camera.main é null; pódese engadir
// esa comprobación se se necesita maior robustez.
public class SimpleNavigationAgentController : MonoBehaviour
{   

    // Executado en cada frame; detecta clics e move o axente se procede.
    void Update()
    {
        // Se se preme o botón esquerdo do rato neste frame
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Crea un Ray desde a cámara principal cara á posición do cursor
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            // Se o Ray acerta nalgún collider, usa ese punto como destino do axente
            if (Physics.Raycast(ray, out hit))
            {
                // Obteñen o NavMeshAgent do mesmo GameObject e establecen o destino
                this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hit.point);
            }
        }
    } 
}