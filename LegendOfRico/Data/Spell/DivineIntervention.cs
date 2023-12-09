namespace LegendOfRico.Data;

public class DivineIntervention : Spells
{
    public override string SpellName { get; protected set; } = "Intervention divine (3/3)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public int MinValue => 60;
    public int MaxValue => 80;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += (int)(player.Statistics / 50 * damageRoll);

            int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
            healRoll += (int)(player.Statistics / 50 * healRoll);

            target.TakeDamage(damageRoll);
            player.ReceiveHeal(healRoll);

            if (target.MonsterType == TypeOfMonster.Undead)
            {
                target.Burnt();
                target.TakeDamage(target.MonsterHP / 10);
                s += s += "Votre cible brûle ! ";
            }
            if (player.PartyMember != null)
            {
                player.PartyMember.ReceiveHeal(healRoll);
                s += player.Name + " soigne le groupe de " + healRoll + " points de vie ";
            }
            else
            {
                s += player.Name + " est soigné de " + healRoll + " points de vie ";
            }
            s += player.Name + "et inflige " + damageRoll + " points de dégâts à la cible ! ";
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