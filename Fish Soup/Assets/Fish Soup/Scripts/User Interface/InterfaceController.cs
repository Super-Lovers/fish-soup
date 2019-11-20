using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    /// <summary>
    /// Activates the given game object
    /// </summary>
    /// <param name="obj"></param>
    public void Open(Object obj)
    {
        GameObject uiGameObject = obj as GameObject;
        if (uiGameObject.activeSelf == false)
        {
            uiGameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Deactivates the given game object
    /// </summary>
    /// <param name="obj"></param>
    public virtual void Close(Object obj)
    {
        GameObject uiGameObject = obj as GameObject;
        if (uiGameObject.activeSelf == true)
        {
            uiGameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Reverses the active self state of that object
    /// </summary>
    /// <param name="obj"></param>
    public void Toggle(Object obj)
    {
        GameObject uiGameObject = obj as GameObject;
        uiGameObject.SetActive(!uiGameObject.activeSelf);
    }
}