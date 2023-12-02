using System.ComponentModel.DataAnnotations;

namespace LegendOfRico.Data
{
    public class CharacterModel
    {
        [Required(ErrorMessage = "Le champ 'Nom du personnage' est obligatoire.")]
        public string CharacterName { get; set; }
        public TypeOfCharacter SelectedType { get; set; } = TypeOfCharacter.Magicien;
    }
}
