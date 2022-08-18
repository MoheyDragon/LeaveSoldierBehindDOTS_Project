using Unity.Transforms;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
namespace DotsTranslationTest
{
    public partial class MovmentSystem : SystemBase
    {
        private EntityQuery _regualrMoveQuery, _specialMoveQuery;
        protected override void OnStartRunning()
        {
            _regualrMoveQuery = EntityManager.CreateEntityQuery(
                ComponentType.ReadWrite<Translation>(),
                ComponentType.ReadOnly<MoveSpeed>(),
                ComponentType.Exclude<SpecialMoveTag>());

            _specialMoveQuery = EntityManager.CreateEntityQuery(
                ComponentType.ReadWrite<Translation>(),
                ComponentType.ReadOnly<MoveSpeed>(),
                ComponentType.ReadOnly<SpecialMoveTag>());
        }
        protected override void OnUpdate()
        {
            var job =new MoveJob { DeltaTime = Time.DeltaTime ,MoveMod=1};
            job.ScheduleParallel(_regualrMoveQuery);
            job.MoveMod = .25f;
            job.ScheduleParallel(_specialMoveQuery);    
        }
    }
    [BurstCompile]
    public partial struct MoveJob:IJobEntity
    {
        public float DeltaTime;
        public float MoveMod;
        void Execute(ref Translation translation,in MoveSpeed moveSpeed)
        {
            translation.Value += math.forward() * moveSpeed.value * DeltaTime * MoveMod;
        }
    }
}

