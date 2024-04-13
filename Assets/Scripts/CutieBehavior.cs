using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutieBehavior : MonoBehaviour
{
    public static CutieBehavior Instance;

    public bool IsInstantiated = false;

    public List<GameObject> Cuties;

    public Transform[] JurorSeats;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Running)
        {

        }
    }

    public void InstantiateJurors()
    {
        IsInstantiated = true;

        for(int i = 0; i < 8; i++)
        {
            int rng = Random.Range(0, Cuties.Count);

            Instantiate(
                Cuties[rng],
                JurorSeats[i]
            );

            Cuties.RemoveAt(rng);
        }
    }
}
