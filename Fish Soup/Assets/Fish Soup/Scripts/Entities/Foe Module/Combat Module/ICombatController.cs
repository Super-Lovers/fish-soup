public interface ICombatController
{
    void DamageEntity(FoeEntityModel entity);
    int GetDamage();
    void SetDamage(int damage);
    AbilitiesController GetAbilitiesController();
}