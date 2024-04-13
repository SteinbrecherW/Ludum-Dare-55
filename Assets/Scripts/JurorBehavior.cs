using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurorBehavior : MonoBehaviour
{
    bool _highlighted = false;

    public Material JurorMaterial;

    public CutieData JurorData;

    //void Start()
    //{
        
    //}

    //void Update()
    //{
        
    //}

    private void OnMouseDown()
    {
        if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Running)
        {
            if (!_highlighted)
            {
                Camera.main.transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z - 5
                );

                _highlighted = true;
            }
            else
            {
                if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Running)
                {
                    Camera.main.transform.position = GameBehavior.Instance.MainCameraPosition;
                }

                _highlighted = false;
            }
        }
    }
}
