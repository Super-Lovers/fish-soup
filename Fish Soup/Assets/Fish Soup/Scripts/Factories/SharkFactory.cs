using UnityEngine;
using Zenject;

public class SharkFactory : MonoBehaviour
{
    private SharkEntity.Factory sharkFactory;

    private float countdown = 3;
    private float currentTime = 0;

    [Inject]
    public void Construct(SharkEntity.Factory sharkFactory)
    {
        this.sharkFactory = sharkFactory;
    }
}
