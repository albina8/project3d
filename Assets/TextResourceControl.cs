using UnityEngine;
using UnityEngine.UI;


public class TextResourceControl : MonoBehaviour
{
    public Text text;
    public string resourceName;

    private void ChangeText(float resourceValue)
    {
        text.text = ((int)resourceValue).ToString();
    }

    private void Start()
    {
        var resource = PlayerResource.Find(resourceName);
        ChangeText(resource.GetValue());
        resource.ValueChangeEvent += ChangeText;
    }
}