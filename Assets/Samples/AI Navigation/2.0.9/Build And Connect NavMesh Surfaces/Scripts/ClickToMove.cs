using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    // Clase de exemplo que move un NavMeshAgent á posición onde o usuario fai
    // clic co botón esquerdo do rato.
    //
    // Comportamento principal:
    // - Cando o usuario fai clic co botón esquerdo (mouse button 0) e NON está
    //   a premer a tecla LeftShift, créase un Raycast desde a cámara principal
    //   cara ao punto marcado polo cursor.
    // - Se o Raycast acerta nun collider, establécese o destino do NavMeshAgent
    //   para o punto de impacto.
    //
    // Nota:
    // - Este script require que o GameObject teña un componente NavMeshAgent
    //   (veña asegurado polo atributo RequireComponent).
    // - Usa Camera.main; se non hai ningunha cámara marcada como MainCamera,
    //   Camera.main será null e podería causar un erro se non se comproba.
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClickToMove : MonoBehaviour
    {
        // Referencia ao NavMeshAgent do GameObject.
        // Obtida en Start() mediante GetComponent<NavMeshAgent>().
        NavMeshAgent m_Agent;

        // Estrutura para gardar a información do impacto do Raycast.
        // Reutilízase cada frame para evitar novas asignacións.
        RaycastHit m_HitInfo = new RaycastHit();

        // Inicializa a referencia ao NavMeshAgent.
        void Start()
        {
            // Obteñen o compoñente NavMeshAgent que está no mesmo GameObject.
            m_Agent = GetComponent<NavMeshAgent>();
        }

        // Detecta clics do rato cada frame e, se procede, pon o destino do
        // axente no punto onde se fixo clic.
        void Update()
        {
            // Se se fai clic co botón esquerdo e non está premida a tecla LeftShift
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                // Creación dun raio desde a cámara principal cara á posición do cursor.
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Se o raio acerta nalgún collider, m_HitInfo terá os datos do
                // impacto, e usamos a posición dese punto como destino do axente.
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    m_Agent.destination = m_HitInfo.point;
            }
        }
    }
}