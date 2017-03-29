using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public Transform transform;
    public float speed;
    public float seuil;
    public List<Transform> chemin;

    int index;

    // Use this for initialization
    void Start()
    {
        index = 0;

        Transform objectif = chemin[index];

        float x = transform.position.x;
        float y = transform.position.y;

        float X = objectif.position.x;
        float Y = objectif.position.y;

        Vector3 vectaur = new Vector3(X - x, Y - y, 0);
        transform.Translate(vectaur);
    }

    // Update is called once per frame
    void Update()
    {
        if (isArrivedToPoint())
        {
            index = (index + 1);

            if (index == chemin.Count)
            {
                Destroy(gameObject);
            }
        }
        GoToPoint();
    }

    public bool isArrivedToPoint()
    {
        Transform objectif = chemin[index];

        float x = transform.position.x;
        float y = transform.position.y;

        float X = objectif.position.x;
        float Y = objectif.position.y;

        Vector3 vectorDir = new Vector3(X - x, Y - y, 0);
        float distanceAObjectif = vectorDir.sqrMagnitude;

        return (distanceAObjectif <= seuil);
    }

    public void GoToPoint()
    {
        Transform objectif = chemin[index];

        float x = transform.position.x;
        float y = transform.position.y;

        float X = objectif.position.x;
        float Y = objectif.position.y;

        Vector3 vectorDir = new Vector3(X - x, Y - y, 0);
        vectorDir.Normalize();

        transform.Translate(
            vectorDir * speed * Time.deltaTime);
    }

}