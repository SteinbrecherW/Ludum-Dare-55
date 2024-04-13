using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurorBehavior : MonoBehaviour
{
    bool _highlighted = false;

    public Material JurorMaterial;

    public CutieData JurorData;

    //void Update()
    //{
    //    if(GameBehavior.Instance.CurrentState == GameBehavior.GameState.Focused)
    //    {

    //    }
    //}

    private void OnMouseDown()
    {
        if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Running ||
            GameBehavior.Instance.CurrentState == GameBehavior.GameState.Focused)
        {
            if (!_highlighted)
            {
                Camera.main.transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y - 0.5f,
                    transform.position.z - 5
                );

                _highlighted = true;

                GameBehavior.Instance.NameText.text = JurorData.Name;
                GameBehavior.Instance.DialogueText.text = JurorData.Introduction;

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Focused;
            }
            else
            {
                Camera.main.transform.position = GameBehavior.Instance.MainCameraPosition;

                _highlighted = false;

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Running;
            }
        }
    }
}
