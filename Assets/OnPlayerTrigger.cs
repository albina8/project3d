using UnityEngine;
using UnityEngine.Events;


public class OnPlayerTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent playerEnterEvent;
    [SerializeField] private UnityEvent playerExitEvent;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnterEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerExitEvent.Invoke();
        }
    }
}