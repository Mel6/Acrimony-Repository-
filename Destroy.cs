using UnityEngine;
using UnityEngine.SocialPlatforms;

public class DestoryBasic : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Destory(gameObject);
        }
    }
}
