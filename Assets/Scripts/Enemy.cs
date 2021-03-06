using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    private EnemyStat stats;
    private SpriteRenderer mySpr;
    private int delayBetweenShotsInMilliSeconds = 250;
    Quaternion ShotRot => Quaternion.Euler(0f, 0f, 180f);

    [SerializeField] public EnemyStat.EnemyType myType;
    [SerializeField] GameObject bulletPrefab;


    Color GetColorFromVector3(System.Numerics.Vector3 v) => new Color(v.X, v.Y, v.Z);


    public async void Init(EnemyStat.EnemyType newType)
    {
        mySpr = GetComponent<SpriteRenderer>();
        stats = new EnemyStat(myType);
        mySpr.color = GetColorFromVector3(stats.colorV3);
        if (stats.shotCount == 0) return;
        await Task.Delay(Random.Range(2000, stats.shotPeriodInMilliSeconds));
        ConstantlyShot();
    }

    private async void Start()
    {
        mySpr = GetComponent<SpriteRenderer>();
        stats = new EnemyStat(myType);
        mySpr.color = GetColorFromVector3(stats.colorV3);
        if (stats.shotCount == 0) return;
        await Task.Delay(Random.Range(2000, stats.shotPeriodInMilliSeconds));
        ConstantlyShot();
    }

    private async void ConstantlyShot()
    {
        while (gameObject != null)
        {
            Shot();
            await Task.Delay(stats.shotPeriodInMilliSeconds);
        }
    }

    async void Shot()
    {
        if (GameLogic.gameLogic.gamePaused) return;
        mySpr.color = Color.red;
        await Task.Delay(delayBetweenShotsInMilliSeconds);
        int shotCount = stats.shotCount;
        while (shotCount > 0)
        {
            Instantiate(bulletPrefab, transform.position, ShotRot);
            shotCount--;
            await Task.Delay(delayBetweenShotsInMilliSeconds);
        }
        mySpr.color = GetColorFromVector3(stats.colorV3);
    }


    public void Damaged()
    {
        stats.hp--;
        if (stats.hp <= 0)
            DestroyEnemy();
    }

    private void DestroyEnemy() => GameLogic.gameLogic.DestroyEnemy(this);

}
