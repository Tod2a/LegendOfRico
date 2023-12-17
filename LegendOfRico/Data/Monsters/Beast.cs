namespace LegendOfRico.Data;

public abstract class Beast : Monster
{
    public Boolean IsSoothed { get; private set; }
    public int SoothDuration { get; private set; }
    public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Beast;
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Fire };
    public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
    public abstract int PetMinDamage { get; protected set; }
    public abstract int PetMaxDamage { get; protected set; }
    public override TypeOfDamage[] MonsterResistance => new TypeOfDamage[] { };

    //Fonctions propres aux b�tes qui peuvent �tre apais�es par le ranger

    //Fonction qui va apaiser la b�tre et mettre la dur�e � 5 tours
    public void Soothed()
    {
        IsSoothed = true;
        SoothDuration = 5;
    }

    //Fonction qui va v�rifier si la b�te est apais�e, modifier les d�gats si c'est le cas et ensuite retourner un int qui sont
    //les d�gats apr�s cette v�rification
    public int DamageSoothed(int damageToSooth)
    {
        int postSoothDamage = damageToSooth;
        if (IsSoothed)
        {
            postSoothDamage /= 2;
            SoothDuration--;
            IsSoothed = (SoothDuration <= 0) ?false:true;
        }
        return postSoothDamage;
    }
}