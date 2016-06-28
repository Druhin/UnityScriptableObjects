using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	private Text text;
	private Vector3 destination;
    public EnemyTemplate enemyTemplate;

	void Awake()
	{
		SetRandomDestination();
		text = GetComponentInChildren<Text>();
	}
	
	void Start()
	{
	}
	
	void Update()
	{
		if( Vector3.Distance( transform.position, destination ) < 0.01f )
		{
			SetRandomDestination();
		}
        //early exit
        if (!enemyTemplate)
            return;
        if(text)
        {
            text.text = "HP\n" + enemyTemplate.maximumHitPoints.ToString();
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, enemyTemplate.speed * Time.deltaTime);
	}
	
	private void SetRandomDestination()
	{
		destination = Vector3.left * Random.Range( -4.0f, 4.0f ) + Vector3.forward * Random.Range( -4.0f, 4.0f );
	}
}








