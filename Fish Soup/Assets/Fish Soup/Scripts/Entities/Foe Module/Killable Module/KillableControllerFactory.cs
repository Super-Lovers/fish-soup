public class KillableControllerFactory
{
    public KillableController Create(FoeEntityModel entity)
    {
        return new KillableController(entity);
    }
}