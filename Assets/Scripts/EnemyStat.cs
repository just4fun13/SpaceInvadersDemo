using System.Numerics;

public class EnemyStat 
{
    public int hp { get; set; }
    public int shotCount { get; set; }

    public int shotPeriodInMilliSeconds { get; set; }
    public Vector3 colorV3;

    private Vector3 GreenV => new Vector3(0f, 1f, 0f);
    private Vector3 YellowV => new Vector3(1f, 1f, 0f);
    private Vector3 OrangeV => new Vector3(1f, .5f, 0f);
    private Vector3 RedV => new Vector3(1f, 0f, 0f);


    public enum EnemyType { easy, normal, hard, super };
    public EnemyStat (EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.easy:
                colorV3 = GreenV;
                hp = 1;
                shotCount = 0;
                break;
            case EnemyType.normal:
                colorV3 = YellowV;
                hp = 2;
                shotCount = 1;
                shotPeriodInMilliSeconds = 10000;
                break;
            case EnemyType.hard:
                colorV3 = OrangeV;
                hp = 2;
                shotCount = 2;
                shotPeriodInMilliSeconds = 10000;
                break;
            case EnemyType.super:
                colorV3 = RedV;
                hp = 3;
                shotCount = 3;
                shotPeriodInMilliSeconds = 10000;
                break;
        }
    }
}

