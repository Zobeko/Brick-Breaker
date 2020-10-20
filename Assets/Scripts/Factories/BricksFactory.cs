using System.Collections.Generic;
using UnityEngine;

public class BricksFactory : MonoBehaviour
{
    public static BricksFactory instance;

    [SerializeField] private GameObject simpleBrickPrefab = null;
    [SerializeField] private int numberOfBricksToPreinstantiate = 0;

    private int brickCount = 0;
    private Dictionary<BrickAvatar.BrickType, Queue<BrickAvatar>> availableBrickByType = new Dictionary<BrickAvatar.BrickType, Queue<BrickAvatar>>();

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        foreach (object value in System.Enum.GetValues(typeof(BrickAvatar.BrickType)))
        {
            this.availableBrickByType.Add((BrickAvatar.BrickType)value, new Queue<BrickAvatar>());
        }
    }

    void Start()
    {
        if (simpleBrickPrefab == null)
        {
            Debug.LogError("simpleBrickPrefab is not set !");
            return;
        }

        PreinstantiateBrick(BrickAvatar.BrickType.simpleBrick, numberOfBricksToPreinstantiate);
    }

    public static BrickAvatar GetBrick(BrickAvatar.BrickType brickType)
    {
        Queue<BrickAvatar> availableBricks = BricksFactory.instance.availableBrickByType[brickType];
        BrickAvatar avatar;

        if(availableBricks.Count > 0)
        {
            avatar = availableBricks.Dequeue();
        }
        else
        {
            avatar = InstantiateBrick(brickType);
        }

        avatar.gameObject.SetActive(true);

        return avatar;

    }

    public static BrickAvatar InstantiateBrick(BrickAvatar.BrickType brickType)
    {
        GameObject brick = null;

        switch (brickType)
        {
            case BrickAvatar.BrickType.simpleBrick:
                brick = GameObject.Instantiate(instance.simpleBrickPrefab);
                break;
        }

        brick.SetActive(false);
        brick.transform.parent = BricksFactory.instance.gameObject.transform;

        BrickAvatar avatar = brick.GetComponent<BrickAvatar>();
        BricksFactory.instance.brickCount++;

        return avatar;
    }

    public static void PreinstantiateBrick(BrickAvatar.BrickType brickType, int _numberOfBricksToPreinstantiate)
    {
        Queue<BrickAvatar> availableAvatar = BricksFactory.instance.availableBrickByType[brickType];

        for (int i = 0; i < _numberOfBricksToPreinstantiate; i++)
        {
            BrickAvatar avatar = InstantiateBrick(brickType);

            if(avatar == null)
            {
                Debug.LogError(string.Format("PreinstantiateAvatar() failure to {0} ennemy !", _numberOfBricksToPreinstantiate));
                return;
            }

            availableAvatar.Enqueue(avatar);
        }

    }

    public static void ReleaseBrick(BrickAvatar avatar)
    {
        Queue<BrickAvatar> availableAvatar = instance.availableBrickByType[avatar.brickType];
        avatar.gameObject.SetActive(false);
        availableAvatar.Enqueue(avatar);
    }

}
