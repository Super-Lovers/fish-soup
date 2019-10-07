using Zenject;

public class SharkEntity : EntityModel
{
    private PlayerController player;

    [Inject]
    public void Construct(PlayerController player)
    {
        this.player = player;
    }

    public class Factory : PlaceholderFactory<SharkEntity> { }
}
