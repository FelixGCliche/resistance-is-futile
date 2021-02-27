using Stats;

namespace Equipment
{
  public interface IWeapon: IEquippable
  {
    public int BaseDamage { get; }
    public DamageType DamageType { get; }

    public Attack GetAttack(int target);
  }
}