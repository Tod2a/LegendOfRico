﻿namespace LegendOfRico.Data;

public class Burst : Spells
{
    public override string SpellName => "Explosion";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override string UseSpell(Game currentGame)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            s += "Vous frappez votre cible deux fois dans un excès de rage !";
            currentGame.Player.Hit(currentGame.MonsterFight);
            currentGame.Player.Hit(currentGame.MonsterFight);
            CurrentNumberOfUses--;
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        return s;
    }
}