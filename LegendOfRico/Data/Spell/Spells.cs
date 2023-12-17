using System.Numerics;

namespace LegendOfRico.Data;

public abstract class Spells
{
    public abstract string SpellName { get; protected set; }
    public abstract int MaxNumberOfUses { get; }
    public abstract int CurrentNumberOfUses { get; protected set; }
    public abstract TypeOfDamage SpellType { get; protected set; }

    //Fonction qui va remettre le nombre d'utilisations au maximum et refaire le Nom avec le nombre d'utilisations correct
    public void RefreshSpell()
    {
        CurrentNumberOfUses = MaxNumberOfUses;
        string newSpellName = SpellName.Substring(0, SpellName.IndexOf("(") + 1);
        newSpellName += MaxNumberOfUses + "/" + MaxNumberOfUses + ")";
        SpellName = newSpellName;
    }

    //Fonction qui va
    public string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            s += SpellEffect(player, target);
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }

    //Déclaration de la fonction obligatoire Use pour tout les sorts
    //Cette fonction doit return un texte et modifier le nom du sort pour afficher le nombre d'utilisation restante
    protected abstract string SpellEffect(Character player, Monster target);

    protected bool IsABoss(Monster target)
    {
        return target.GetType() == typeof(Sunwukong) || target.GetType() == typeof(Cheftontaton)
            || target.GetType() == typeof(EternalScorpio) || target.GetType() == typeof(JoyBean) || target.GetType() == typeof(RicoChico);
    }

    protected bool IsResistant(Monster target)
    {
        return target.MonsterResistance.Contains(SpellType);
    }

    protected bool IsWeak(Monster target)
    {
        return target.MonsterWeakness.Contains(SpellType);
    }
        
}