using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BulletSpawnSystem : ComponentSystem
{
    private EntityManager _entityManager;
    private Unity.Mathematics.Random _random;
    protected override void OnCreate()
    {
        base.OnCreate();
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        _random = new Unity.Mathematics.Random(12);
    }

    protected override void OnUpdate()
    {
        if (Input.GetKey(KeyCode.F))
        {
            float3 heroPos = default;
            quaternion heroRot = default;
            float3 heroForward = default;
            float3 heroRight = default;
            int bulletCountPerFire = 0;
            Entities.ForEach(
                (ref HeroComponent heroComponent, ref Translation translation, ref LocalToWorld localToWorld) =>
                {
                    bulletCountPerFire = heroComponent.bulletCountPerFire;
                    heroPos = translation.Value;
                    heroForward = localToWorld.Forward;
                    heroRot = localToWorld.Rotation;
                    heroRight = localToWorld.Right;
                });

            //UnityEngine.Debug.Log($"bulletCountPerFire={bulletCountPerFire}, heroRot={heroRot}, ");


            Entities.ForEach(
              (ref BulletSpawnComponent bulletSpawnComponent, ref Translation translation, ref Rotation rotation
              ) =>
              {
                  while(bulletCountPerFire-- > 0)
                  {
                      Entity bulletEntity = _entityManager.Instantiate(bulletSpawnComponent.prefab);

                      BulletComponent bulletComponent = _entityManager.GetComponentData<BulletComponent>(bulletEntity);

                      float3 spawnPos = heroPos + (math.normalize(heroRight) * _random.NextFloat(-0.5f, 0.5f));
                      bulletComponent.spawnPos = spawnPos;

                      bulletComponent.dir = heroForward;
                      _entityManager.SetComponentData(bulletEntity, bulletComponent);

                      translation.Value = bulletComponent.spawnPos;
                      rotation.Value = heroRot;

                      _entityManager.SetComponentData(bulletEntity, translation);
                      _entityManager.SetComponentData(bulletEntity, rotation);
                  }
                 
              });
        }
           


    }
}
