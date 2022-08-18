using TMPro;
using UnityEngine;
using Unity.Entities;
namespace DotsBattle
{
    public class IJEBattleController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _effectTypeDropDown,
                             _teamSelectDropDown;
        [SerializeField] private TMP_InputField _hitPointsInputField;
        private Entity _spellController;
        private EntityManager _entityManager;
        // Start is called before the first frame update
        void Start()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _spellController = _entityManager.CreateEntityQuery(typeof(SpellController)).GetSingletonEntity();
        }
        public void OnButtonExecute()
        {
            var effectModifer = _effectTypeDropDown.value==0?1:-1;
            var effectAmount =int.Parse(_hitPointsInputField.text)*effectModifer;

            var newSpellExecutionData = new SpellExecutionData
            {
                EffectAmount = effectAmount, TeamId = _teamSelectDropDown.value
            };
            _entityManager.AddComponentData(_spellController, newSpellExecutionData);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}