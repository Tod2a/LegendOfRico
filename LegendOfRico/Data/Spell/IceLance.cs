﻿namespace LegendOfRico.Data;

public class IceLance : Spells
{
    public override string SpellName { get; protected set; } = "Javelot de glace (15/15)";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public int MinValue => 20;
    public int MaxValue => 25;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Cold;

    protected override string SpellEffect(Character player, Monster target)
    {
        string s = "";

        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((player.Statistics / 50) * damageRoll);
      
        if (target.IsCold)
        {
            damageRoll *= 2;
            s += "Coup critique ! ";
            target.SetIsCold(false);
        }
        if (IsResistant(target))
        {
            damageRoll /= 2;
            s += "Peu efficace ! ";
        }
        else if (IsWeak(target))
        {
            damageRoll *= 2;
            s += "Efficace ! ";
        }
        target.TakeDamage(damageRoll);
        CurrentNumberOfUses--;
        SpellName = "Javelot de glace (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        return s + player.Name + " inflige " + damageRoll + " points de dégâts à la cible ! ";

    }
}