using UnityEngine;


public class ResourceSource : MonoBehaviour
{
    public string resourceName;
    public float value;

    public void CollectResource(bool destroyObject)
    {
        PlayerResource.Find(resourceName).ChangeValue(value);
        if (destroyObject)
        {
            Destroy(gameObject);
        }
    }
}