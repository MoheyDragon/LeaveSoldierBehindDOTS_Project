using Unity.Entities;

namespace DotsBattle
{
    [GenerateAuthoringComponent]
    public struct HealthPoints : IComponentData
    {
        public int Current,Max;
    }
}
