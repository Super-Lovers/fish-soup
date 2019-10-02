using UnityEngine;

[ExecuteInEditMode]
public class SnapToLevelGrid : MonoBehaviour
{
    public MeshRenderer meshRenderer = null;
    public Material outOfBoundsMaterial = null;
    public Material inBoundsMaterial = null;

    private void Update()
    {
        if (transform.hasChanged)
        {
            transform.position = LevelGrid.GetInstance().SnapToGridCoordinates(transform.position);

            if (LevelGrid.GetInstance().IsInBoundaries(transform.position))
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
