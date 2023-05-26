using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour, IGun
{
    /// <summary>
    /// Name of the gun
    /// </summary>
    new string name = "FlameThrower";
    /// <summary>
    /// Cooldown of the pistol
    /// </summary>
    float cooldown = .05f;
    /// <summary>
    /// Is the weapon on coolDown
    /// </summary>
    bool onCooldown = false;

    /// <summary>
    /// Who can damage this weapon
    /// </summary>
    Bullet.AppliesDamageTo appliesDamageTo;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject bulletOrigin;

    [SerializeField]
    int recoil = 50;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public float GetCooldown()
    {
        return cooldown;
    }


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int Shoot(Vector3 selectedPoint)
    {
        if (onCooldown)
            return -1;
        StartCoroutine(Cooldown());
        Vector3 dir = VectorTools.DirectionXZ(bulletOrigin.transform.position, selectedPoint);
        GameObject b = GameObject.Instantiate(bullet, bulletOrigin.transform.position, transform.rotation);
        b.GetComponent<Bullet>().Initialize(appliesDamageTo, dir);
        return 1;
    }

    /// <summary>
    /// Cooldown coroutine that sets the pistol on cooldown for the amount of seconds specified
    /// </summary>
    /// <returns></returns>
    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return name;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public Bullet.AppliesDamageTo GetAppliesDamageTo()
    {
        return appliesDamageTo;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="damageTo"></param>
    public void SetAppliesDamageTo(Bullet.AppliesDamageTo damageTo)
    {
        appliesDamageTo = damageTo;
    }
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int GetRecoil()
    {
        return recoil;
    }
}
