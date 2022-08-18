using Unity.Entities;

[GenerateAuthoringComponent]
public struct SoldierTag:IComponentData
{
    public bool IsWithSquad;
}
