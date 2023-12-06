namespace LegendOfRico.Data;

public class Tame : Spells
{
    public override string SpellName { get; protected set; } = "Apprivoiser";
    public override int MaxNumberOfUses => 99;
    public override int CurrentNumberOfUses { get; protected set; } = 99;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            if(target.MonsterType == TypeOfMonster.Beast)
            {
                var beastMonster = (Beast)target;
                if (target.MonsterCurrentHP >= target.MonsterHP / 2)
                {
                    s += "La cible n'est pas encore assez affaiblie !";
                }
                else
                {
                    Random dice = new Random();
                    double diceRoll = dice.NextDouble();
                    if(diceRoll < 0.5)
                    {
                        s += "L'apprivoisement de la bête à échoué";
                    }
                    else
                    {
                        var ranger = (Ranger)player;
                        ranger.NewPetTamed(beastMonster);
                        beastMonster.TakeDamage(99999);
                        s += "Vous avez apprivoisé un " + beastMonster.MonsterName + " !";
                    }
                }
            }
            else
            {
                s += "Vous ne pouvez apprivoiser que les bêtes !";
            }
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}