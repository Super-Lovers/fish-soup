[System.Serializable]
public class CombatController : ICombatController
{
    [UnityEngine.SerializeField]
    private int damage;

    public void DamageEntity(FoeEntityModel entity)
    {
        entity.GetKillableController().InflictDamage(damage);
    }

    public int GetDamage()
    {
        return this.damage;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}