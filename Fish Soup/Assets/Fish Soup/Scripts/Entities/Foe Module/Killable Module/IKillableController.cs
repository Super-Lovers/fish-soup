public interface IKillableController
{
    void InflictDamage(int damage);
    bool ValidateDamage(int health, int damage);
    IDeathController GetDeathController();
}