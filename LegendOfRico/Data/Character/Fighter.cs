﻿namespace LegendOfRico.Data
{
    public class Fighter: Character
    {
        public override TypeOfWeapon[] WeaponMastery =>
            new[] { TypeOfWeapon.Axe, TypeOfWeapon.Sword, TypeOfWeapon.Greatsword };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Heavy;
        public override Weapon CharacterWeapon { get; protected set; } = new Sword("Epée en bois", 5, 2, 3);
        public override Shield CharacterShield { get; protected set; } = new Shield("Bouclier en bois", 0, 3);
        public override Armor CharacterArmor { get; protected set; } = new Armor("Haillons", 5, TypeOfArmor.Light, 1);
        public override bool CanEquipShield { get; protected set; } = true;
        public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Burst()};
        public override int MaxHitPoints => 30;
        public override int CurrentHitPoints { get; set; } = 30;
        public override int ArmorAmount { get; protected set; } = 4;
        public override double ChanceToDodge { get; protected set; } = 0.1;
        public override string fightImgUrl { get; } = "img/Character/fightFighter.png";

        protected override void CheckLearnSpell()
        {
            if (Level == 3)
            {
                //Spell à défini
            }
        }
        public void EquipGreatsword(Weapon greatsword)
        {
            EquipWeapon(greatsword);
            CanEquipShield = false;
        }

        public void UnequipGreatsword()
        {
            UnequipWeapon();
            CanEquipShield = true;
        }
    }
}
