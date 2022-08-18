using TMPro;
using Unity.Entities;
using UnityEngine.UI;
namespace DotsBattle
{
    public class BattleEntityManaged : IComponentData
    {
        public Image CharacterImage;
        public Slider HealthBarUI;
        public TextMeshProUGUI HealthText;
    }
}