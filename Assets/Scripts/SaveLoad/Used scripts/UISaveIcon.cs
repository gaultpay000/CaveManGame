using UnityEngine;

public class UISaveIcon : MonoBehaviour
{

    [SerializeField]GameObject saveObject;

    [SerializeField]Renderer render;

    [SerializeField]GameObject saveIcon;
    bool isSavable = false;

    // Update is called once per frame
    void Update()
    {
        if (isSavable && render.isVisible)
        {
            saveIcon.transform.position = Camera.main.WorldToScreenPoint(saveObject.transform.position);
        }
    }

    public void Savable()
    {
        isSavable = true;
    }

    public void Unsavable()
    {
        isSavable = false;
    }
}
