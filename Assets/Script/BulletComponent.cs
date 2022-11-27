using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct BulletComponent : IComponentData
{
    public float speed;
    public float maxDistance;
    public float3 dir;
    public float3 spawnPos;
}
