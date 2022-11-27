using Unity.Entities;

[GenerateAuthoringComponent]
public struct HeroComponent : IComponentData
{
    public float moveSpeed;
    public float rotSpeed;
    public int bulletCountPerFire;
}
