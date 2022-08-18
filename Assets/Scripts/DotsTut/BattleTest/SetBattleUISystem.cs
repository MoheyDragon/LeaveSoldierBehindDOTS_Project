using Unity.Entities;
namespace DotsBattle
{
    [UpdateAfter(typeof(PerformSpellSystem))]
    public partial class SetBattleUISystem : SystemBase
    {
        protected override void OnStartRunning()
        {
            Entities.ForEach((BattleEntityManaged battleEntityManaged, ref HealthPoints healthPoint) =>
            {
                healthPoint.Current = healthPoint.Max;
                battleEntityManaged.HealthText.text = $"{healthPoint.Current}/{healthPoint.Max}";
                battleEntityManaged.HealthBarUI.value = 1f;
            }).WithoutBurst().Run();
        }

        protected override void OnUpdate()
        {
            Entities
                .WithChangeFilter<HealthPoints>()
                .ForEach((BattleEntityManaged battleEntityManaged, ref HealthPoints healthPoint) =>
                {
                    battleEntityManaged.HealthText.text = $"{healthPoint.Current}/{healthPoint.Max}";
                    battleEntityManaged.HealthBarUI.value = (float)healthPoint.Current / healthPoint.Max;
                }).WithoutBurst().Run();
        }
    }
}