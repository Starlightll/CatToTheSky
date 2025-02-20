using UnityEngine;
using System.Linq;
using Mono.Cecil;
using System.Collections.Generic;

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
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(x => x.transform.position.y).ToList();
        float count = 0;
        foreach (GameObject enemy in enemies)
        {
            if (count < size)
            {
                if (enemies.Count % 2 == 0)
                {
                    if (count % 2 == 0)
                    {
                        FireMissile(new Vector2(count, 1), true, speed, rotationSpeed, startPos, enemy);
                    }
                    else
                    {
                        FireMissile(new Vector2(-count + 1f, 1), true, speed, rotationSpeed, startPos, enemy);
                    }
                }
                else
                {
                    if (count == 0)
                    {
                        FireMissile(new Vector2(0, 1), true, speed, rotationSpeed, startPos, enemy);
                    }
                    else if (count % 2 == 0)
                    {
                        FireMissile(new Vector2(count, 1), true, speed, rotationSpeed, startPos, enemy);
                    }
                    else
                    {
                        FireMissile(new Vector2(-count + 1f, 1), true, speed, rotationSpeed, startPos, enemy);
                    }
                }
                count++;
            }
        }
        int remaining = size - enemies.Count;
        if (remaining > 0)
        {
            for (int i = 0; i < remaining; i++)
            {
                if (remaining % 2 == 0)
                {
                    if (i % 2 == 0)
                    {
                        FireMissile(new Vector2(i, 1), true, speed, rotationSpeed, startPos, null);
                    }
                    else
                    {
                        FireMissile(new Vector2(-i + 1f, 1), true, speed, rotationSpeed, startPos, null);
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        FireMissile(new Vector2(0, 1), true, speed, rotationSpeed, startPos, null);
                    }
                    else if (i % 2 == 0)
                    {
                        FireMissile(new Vector2(i, 1), true, speed, rotationSpeed, startPos, null);
                    }
                    else
                    {
                        FireMissile(new Vector2(-i + 1f, 1), true, speed, rotationSpeed, startPos, null);
                    }
                }
            }
        }
    }


    public void Skill_1(float speed, float rotationSpeed, Transform startPos)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            GameObject target = enemies.OrderBy(x => Vector2.Distance(startPos.position, x.transform.position)).First();
            FireMissile(new Vector2(0, 1), true, speed, rotationSpeed, startPos, target);
        }
        else {
            FireMissile(new Vector2(0, 1), true, 20f, 1000f, startPos, null);
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
