﻿namespace LegendOfRico.Data
{
    public class BowmanBandit: Humanoid
    {
        public int ArrowMinDmg = 10;
        public int ArrowMaxDmg = 20;

        public TypeOfWeapon[] BowmanBanditWeapoon = new TypeOfWeapon[] {TypeOfWeapon.Bow, TypeOfWeapon.Dagger};

        public int ClubMinDmg = 1;
        public int ClubMaxDmg = 2;

        public void ShootArrow(Character target)
        {
            // effet a définir
        }

        public void Club()
        {
            // effet a definir
        }
    }
}
