using UnityEngine;

[ExecuteInEditMode]
public class SnapToLevelGridController : MonoBehaviour
{
    public MeshRenderer meshRenderer = null;
    public Material outOfBoundsMaterial = null;
    public Material inBoundsMaterial = null;

    private void Update()
    {
        if (transform.hasChanged)
        {
            transform.position = LevelGridView.GetInstance().SnapToGridCoordinates(transform.position);

            if (LevelGridView.GetInstance().IsInBoundaries(transform.position))
            {
                meshRenderer.material = inBoundsMaterial;
            }
            else
            {
                meshRenderer.material = outOfBoundsMaterial;
            }
        }
    }
}
