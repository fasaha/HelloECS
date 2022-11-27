using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public class HeroSystem : ComponentSystem
{
    private const string AXIS_H = "Horizontal";
    private const string AXIS_V = "Vertical";

    protected override void OnCreate()
    {
        base.OnCreate();
    }

    
    protected override void OnUpdate()
    {
        float axisV = Input.GetAxis(AXIS_V);
        float axisH = Input.GetAxis(AXIS_H);

        if (!Mathf.Approximately(axisV, 0F) ||
            !UnityEngine.Mathf.Approximately(axisH, 0F))
        {
            Entities.ForEach(
                        (ref HeroComponent heroComponent, ref Translation translation, ref Rotation rotation, ref LocalToWorld localToWorld) =>
                        {

                            if (!Mathf.Approximately(axisV, 0F))
                            {
                                translation.Value += localToWorld.Forward * heroComponent.moveSpeed * axisV * Time.DeltaTime;
                            }
                            if (!UnityEngine.Mathf.Approximately(axisH, 0F))
                            {
                                rotation.Value = math.mul(math.normalize(rotation.Value),
                                    quaternion.AxisAngle(math.up(), heroComponent.rotSpeed * axisH * Time.DeltaTime));

                            }

                        });
        }
        



    }
}
