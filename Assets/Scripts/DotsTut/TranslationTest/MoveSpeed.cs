using Unity.Entities;

namespace DotsTranslationTest
{
    [GenerateAuthoringComponent]
    public partial struct MoveSpeed : IComponentData
    {
        public float value;
    }

}
