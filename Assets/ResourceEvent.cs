using UnityEngine;
using UnityEngine.Events;


public class ResourceEvent : MonoBehaviour
{
    public string resourceName = "firstKey";
    public float requiredAmount = 1;
    public UnityEvent OnEnoughResource;

    public void TryInvoke()
    {
        var resource = PlayerResource.Find(resourceName);
        if (resource && resource.GetValue() >= requiredAmount)
        {
            OnEnoughResource.Invoke();
        }
    }
}