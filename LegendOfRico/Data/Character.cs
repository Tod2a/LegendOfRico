using System.ComponentModel;

namespace LegendOfRico.Data;

public abstract class Character : INotifyPropertyChanged
{
    public string Name { get; set; }
    public int Level { get; private set; } = 1;
    public int MaxHitPoints { get; private set; }
    public int CurrentHitPoints { get; private set; }
    public Dictionary<Stats, int> Statistics { get; private set; }
    public int ArmorAmount { get; private set; }
    public Weapon CharacterWeapon { get; private set; }
    public Armor CharacterArmor { get; private set; }
    public Item[] Inventory { get; private set; }
    public abstract TypeOfWeapon[] WeaponMastery { get; }
    public abstract TypeOfArmor ArmorMastery { get; }
    private int positionI = 10; 

    public int PositionI
    {
        get { return positionI; }
        private set
        {
            if (value != positionI)
            {
                positionI = value;
                OnPropertyChanged(nameof(PositionI));
            }
        }
    }
    private int positionJ = 10; 

    public int PositionJ
    {
        get { return positionJ; }
        private set
        {
            if (value != positionJ)
            {
                positionJ = value;
                OnPropertyChanged(nameof(PositionJ));
            }
        }
    }
    public string MapSprite {  get; set; }

    public void CreateCharacter()
    {
        //To be defined
    }

    public void Hit(Monster target)
    {
        int WeaponDamageRoll =
            (new Random()).Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
        if ((new Random()).NextDouble() <= CharacterWeapon.WeaponCritChance) //Si l'arme crit dégâts x2
        {
            WeaponDamageRoll *= 2;
        }
        target.TakeDamage(WeaponDamageRoll);
    }

    public void ReceiveHeal(int HealAmount)
    {
        if (CurrentHitPoints + HealAmount > MaxHitPoints)
        {
            CurrentHitPoints = MaxHitPoints;
        }
        else
        {
            CurrentHitPoints += HealAmount;
        }
    }

    public void GoUp()
    {
        if (PositionI > 0)
        {
            PositionI--;
        }
    }

    public void GoDown()
    {
        if (PositionI < 19)
        {
            PositionI++;
        }
    }

    public void GoLeft()
    {
        if (PositionJ > 0)
        {
            PositionJ--;
        }
    }

    public void GoRight()
    {
        if (PositionJ < 19)
        {
            PositionJ++;
        }
    }

    //gestion du changement des propriété lorsqu'on se déplace sur la carte, permet de réactualiser la carte lors d'un mouvement
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}