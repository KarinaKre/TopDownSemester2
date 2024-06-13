using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    public GameObject heartprefab;
    public Health health;
    List<HealthHeart> hearts = new List<HealthHeart>();


    private void OnEnable()
    {
        Health.OnPlayerDamaged += DrawHearts;
    }



    private void OnDisable()
    {
        Health.OnPlayerDamaged -= DrawHearts;
    }

    private void Start()
    {
        DrawHearts();
    }


    public void DrawHearts()
    {
        ClearHearts();
        float maxHealthRemainder = health.maxHealth % 2;
        int heartsToMake = (int)((health.maxHealth / 2) + maxHealthRemainder);

        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i<hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(health.health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus) heartStatusRemainder);
        }
        
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartprefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart> ();
    }




    

}
