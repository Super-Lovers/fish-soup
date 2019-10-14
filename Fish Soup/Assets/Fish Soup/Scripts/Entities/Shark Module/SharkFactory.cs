using UnityEngine;
using Zenject;

public class SharkFactory : MonoBehaviour
{
    private SharkEntity.Factory sharkFactory;

    [Inject]
    public void Construct(SharkEntity.Factory sharkFactory)
    {
        this.sharkFactory = sharkFactory;
    }
}
