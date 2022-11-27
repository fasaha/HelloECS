using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BulletSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach(
           (Entity entity, ref BulletComponent bulletComponent, ref Translation translation, ref Rotation rotation) =>
           {
               translation.Value += (math.normalize(bulletComponent.dir) * bulletComponent.speed *  Time.DeltaTime);
               if(math.distance(translation.Value, bulletComponent.spawnPos) >= bulletComponent.maxDistance)
               {
                   World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(entity);
               }

           });
    }
}
