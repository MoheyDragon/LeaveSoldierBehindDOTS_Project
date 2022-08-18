using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace DotsBattle
{
    [BurstCompile]
    public partial struct PreformSpellJob : IJobEntity
    {
        public int effectAmount;
        public EntityCommandBuffer.ParallelWriter ECB;
        public void Execute(Entity e, [EntityInQueryIndex]int sortKey,ref HealthPoints healthPoints)
        {
            var currentHealthPoints = healthPoints.Current;
            currentHealthPoints -= effectAmount;
            currentHealthPoints= math.clamp(currentHealthPoints, 0, healthPoints.Max);
            if (currentHealthPoints<=0)
            {
                ECB.AddComponent<DestroyEntityTag>(sortKey, e);
            }
            healthPoints.Current = currentHealthPoints;
        }
    }

}
