using System.ComponentModel.DataAnnotations;

namespace LegendOfRico.Data
{
    //Class Model utilisée pour le Formulaire de création de personnage
    public class CharacterModel
    {
        // rend le champ CharacterNam 'requis' et affiche le message d'erreur sinon
        [Required(ErrorMessage = "Le champ 'Nom du personnage' est obligatoire.")]
        public string CharacterName { get; set; }
        public TypeOfCharacter SelectedType { get; set; } 
    }
}
