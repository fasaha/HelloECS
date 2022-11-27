using Unity.Entities;
using Unity.Mathematics;

[System.Serializable]
public struct BulletSpawnComponent : IComponentData
{
    public Entity prefab;
}
