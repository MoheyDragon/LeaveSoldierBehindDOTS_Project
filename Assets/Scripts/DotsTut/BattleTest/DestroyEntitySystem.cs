using Unity.Entities;
using UnityEngine;

namespace DotsBattle
{
    public partial class DestroyEntitySystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<HealthPoints, DestroyEntityTag>()
                .ForEach((Entity e, BattleEntityManaged battleEntityManaged) =>
                {
                    battleEntityManaged.CharacterImage.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                    EntityManager.DestroyEntity(e);
                }).WithStructuralChanges().WithoutBurst().Run();
        }
    }
}