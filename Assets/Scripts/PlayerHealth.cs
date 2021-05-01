using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	public float health = 100;
    private SceneChanger sc;

    private void Start()
    {
        sc = FindObjectOfType<SceneChanger>();
    }
    public void TakeDamage(float damage)
	{
		health -= damage;

        StartCoroutine(DamageAnimation());

		if (health <= 0)
		{
            if(gameObject.name == "Player" && !sc.PlayerDead && !sc.EnemyDead)
            {
                sc.death(1);
            }
            else if (gameObject.name == "Enemy" && !sc.EnemyDead && !sc.PlayerDead)
            {
                sc.death(2);
            }
        }
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}

}
