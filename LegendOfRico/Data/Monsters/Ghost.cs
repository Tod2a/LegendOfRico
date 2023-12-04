namespace LegendOfRico.Data
{
    public class Ghost : Undead
    {
        public int HitMinDmg = 1;
        public int HitMaxDmg = 2;
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Bat;
    }
}
