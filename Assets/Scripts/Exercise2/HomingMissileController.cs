using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Random = UnityEngine.Random;

public class HomingMissileController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject missilePrefab;

    void Start()
    {
        ////Start the missile with a random direction above the player
        //startDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f));
        
    }

    void Update()
    {
        
    }

    public void FireMissile(Vector2 Direction, bool isHoming, float speed, float rotationSpeed, Transform startPos, GameObject target)
    {
        GameObject missile = Instantiate(missilePrefab, startPos.position, startPos.rotation);
        MissileMovement missileMovement = missile.GetComponent<MissileMovement>();
        missileMovement.startDirection = Direction;
        missileMovement.isHoming = isHoming;
        missileMovement.homingSpeed = speed;
        missileMovement.rotationSpeed = rotationSpeed;
        missileMovement.target = target;

    }

    public void activeUltimate(float speed, float rotationSpeed, Transform startPos, int size)
    {
        StartCoroutine(FireMissilesCoroutine(speed, rotationSpeed, startPos, size));
    }

    private IEnumerator FireMissilesCoroutine(float speed, float rotationSpeed, Transform startPos, int size)
    {
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(x => x.transform.position.y).ToList();
        float count = 0;

        for (int i = 0; i < size+enemies.Count; i++)
        {
            try
            {
                FireMissile(new Vector2(Random.Range(-1f, 1f), 1), true, speed, rotationSpeed, startPos, enemies[i]);
            }
            catch (Exception ex)
            {
                FireMissile(new Vector2(Random.Range(-1f, 1f), 1), true, speed, rotationSpeed, startPos, null);
            }
            yield return new WaitForSeconds(0.05f);
        }
        //foreach (GameObject enemy in enemies)
        //{
        //    if (count < size)
        //    {
        //        if (enemies.Count % 2 == 0)
        //        {
        //            if (count % 2 == 0)
        //            {
        //                FireMissile(new Vector2(count/(count-0.9f), 1), true, speed, rotationSpeed, startPos, enemy);
        //            }
        //            else
        //            {
        //                FireMissile(new Vector2(-count/ (count - 0.9f), 1), true, speed, rotationSpeed, startPos, enemy);
        //            }
        //        }
        //        else
        //        {
        //            if (count == 0)
        //            {
        //                FireMissile(new Vector2(0, 1), true, speed, rotationSpeed, startPos, enemy);
        //            }
        //            else if (count % 2 == 0)
        //            {
        //                FireMissile(new Vector2(count/ (count - 0.9f), 1), true, speed, rotationSpeed, startPos, enemy);
        //            }
        //            else
        //            {
        //                FireMissile(new Vector2(-count/ (count - 0.5f), 1), true, speed, rotationSpeed, startPos, enemy);
        //            }
        //        }

        //        count++;
        //        yield return new WaitForSeconds(0.05f);
        //    }
        //}

        //int remaining = size - enemies.Count;
        //if (remaining > 0)
        //{
        //    for (int i = 0; i < remaining; i++)
        //    {
        //        if (remaining % 2 == 0)
        //        {
        //            if (i % 2 == 0)
        //            {
        //                FireMissile(new Vector2(i, 1), true, speed, rotationSpeed, startPos, null);
        //            }
        //            else
        //            {
        //                FireMissile(new Vector2(-i / (i - 0.9f), 1), true, speed, rotationSpeed, startPos, null);
        //            }
        //        }
        //        else
        //        {
        //            if (i == 0)
        //            {
        //                FireMissile(new Vector2(0, 1), true, speed, rotationSpeed, startPos, null);
        //            }
        //            else if (i % 2 == 0)
        //            {
        //                FireMissile(new Vector2(i / (i - 0.9f), 1), true, speed, rotationSpeed, startPos, null);
        //            }
        //            else
        //            {
        //                FireMissile(new Vector2(-i / (i - 0.5f), 1), true, speed, rotationSpeed, startPos, null);
        //            }
        //        }

        //        yield return new WaitForSeconds(0.05f);
        //    }
        //}

    }


    public void Skill_1(float speed, float rotationSpeed, Transform startPos)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            GameObject target = enemies.OrderBy(x => x.transform.position.y).First();
            FireMissile(new Vector2(0, 1), true, speed, rotationSpeed, startPos, target);
        }
        else {
            FireMissile(new Vector2(0, 1), true, speed, rotationSpeed, startPos, null);
        }
    }

    public void ReTargetRemainMissile()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(x => x.transform.position.y).ToArray();
        GameObject[] remainMissile = GameObject.FindGameObjectsWithTag("Missile");

        for(int i = 0; i<remainMissile.Length; i++)
        {
            try
            {
                remainMissile[i].GetComponent<MissileMovement>().target = enemies[i];
            }
            catch
            {
                remainMissile[i].GetComponent<MissileMovement>().target = null;
            }
        }

        //foreach (GameObject m in remainMissile)
        //{
        //    try
        //    {
        //        GameObject target = enemies.OrderBy(x => Vector2.Distance(m.transform.position, x.transform.position)).
        //        m.GetComponent<MissileMovement>().target = target;
        //    }
        //    catch
        //    {
        //        m.GetComponent<MissileMovement>().target = null;
        //    }
        //}
    }














}
