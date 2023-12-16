namespace LegendOfRico.Data;

public class DivineIntervention : Spells
{
    public override string SpellName { get; protected set; } = "Intervention divine (3/3)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public int MinValue => 60;
    public int MaxValue => 80;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Holy;
    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += (int)(player.Statistics / 50 * damageRoll);

            int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
            healRoll += (int)(player.Statistics / 50 * healRoll);

            player.ReceiveHeal(healRoll);

            if (target.MonsterType == TypeOfMonster.Undead)
            {
                target.Burnt();
                s += s += "Votre cible br�le ! ";
            }
            if (player.PartyMember != null)
            {
                player.PartyMember.ReceiveHeal(healRoll);
                s += player.Name + " soigne le groupe de " + healRoll + " points de vie ";
            }
            else
            {
                s += player.Name + " est soign� de " + healRoll + " points de vie ";
            }

            if (target.MonsterResistance.Contains(SpellType))
            {
                damageRoll /= 2;
                s += "Peu efficace ! ";
            }
            else if (target.MonsterWeakness.Contains(SpellType))
            {
                damageRoll *= 2;
                s += "Efficace ! ";
            }
            target.TakeDamage(damageRoll);

            s += player.Name + "et inflige " + damageRoll + " points de d�g�ts � la cible ! ";
            CurrentNumberOfUses--;
            SpellName = "Intervention divine (" + CurrentNumberOfUses + "/3)";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}