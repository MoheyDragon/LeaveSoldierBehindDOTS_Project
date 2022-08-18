using Unity.Entities;
namespace DotsBattle
{
    public struct SpellExecutionData : IComponentData 
    {
        public int EffectAmount,
                   TeamId;
    }
}
