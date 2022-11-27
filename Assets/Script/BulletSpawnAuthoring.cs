using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BulletSpawnAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    [SerializeField]
    private GameObject _bulletTemplete;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        BulletSpawnComponent bulletSpawnComponent = new BulletSpawnComponent
        {
            // The referenced prefab will be converted due to DeclareReferencedPrefabs.
            // So here we simply map the game object to an entity reference to that prefab.
            prefab = conversionSystem.GetPrimaryEntity(_bulletTemplete),
        };
        dstManager.AddComponentData(entity, bulletSpawnComponent);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(_bulletTemplete);
    }

   
}
