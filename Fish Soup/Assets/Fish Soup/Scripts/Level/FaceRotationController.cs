using UnityEngine;

[ExecuteInEditMode]
public class FaceRotationController : MonoBehaviour
{
    public void RotateView()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Camera.main.transform.rotation, 100);
    }

    private void Update()
    {
        if (transform.hasChanged && Camera.main != null)
        {
            RotateView();
        }
    }
}
