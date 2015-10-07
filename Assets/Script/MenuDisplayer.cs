using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuDisplayer : MonoBehaviour {

    [SerializeField]
    Text text = null;

    Image myImage = null;

    void Start()
    {
        myImage = GetComponent<Image>();
    }

    public void ChangeText(GameObject obj)
    {
        text.text = obj.GetComponent<JuiceType>().Type.ToString();
    }

    public void Enable()
    {
        if (myImage.enabled) return;

        text.enabled = true;
        myImage.enabled = true;
    }

    public void Disable()
    {
        if (!myImage.enabled) return;

        text.enabled = false;
        myImage.enabled = false;
    }
}
