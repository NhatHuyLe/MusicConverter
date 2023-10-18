using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    protected int[,] digital_pic;
    //bool check = false;
    //create a list of game objects
    public List<GameObject> squares = new List<GameObject>();

    public void setDigitalPic(int[,] digital_pic)
    {
        this.digital_pic = digital_pic;
    }

    public int[,] getDigitalPic()
    {
        return digital_pic;
    }

    public void setMusicpad()
    {
        //loop through the digital pic
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                //if the value is 1, set the corresponding square to cyan
                if (digital_pic[x, y] == 1)
                {
                    //find the object "x-y (1)"
                    GameObject square = GameObject.Find(x + "-" + y );
                    square.SetActive(false);
                    //add the square to the list
                    squares.Add(square);
                }
                //if the value is 0, set the corresponding square to black
                else
                {
                    GameObject square = GameObject.Find(x + "-" + y+ " (1)");
                    square.SetActive(false);
                    //add the square to the list
                    squares.Add(square);
                }
            }
        }
    }

    //set the squares to the active state
    public void setSquares()
    {
        foreach (GameObject square in squares)
        {
            square.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        digital_pic=null;
    }

    // Update is called once per frame
    void Update()
    {
        // if (check == false){
        //     //loop through the digital pic
        //     for (int x = 0; x < 16; x++)
        //     {
        //         for (int y = 0; y < 10; y++)
        //         {
        //             GameObject square = GameObject.Find(x + "-" + y );
        //             GameObject square0 = GameObject.Find(x + "-" + y + " (1)");
        //             square.name=x + "-" + (9-y)+ "M";
        //             square0.name=x + "-" + (9-y)+ "M (1)";
        //         }
        //     }
        //     //loop through the digital pic
        //     for (int x = 0; x < 16; x++)
        //     {
        //         for (int y = 0; y < 10; y++)
        //         {
        //             GameObject square = GameObject.Find(x + "-" + y + "M");
        //             GameObject square0 = GameObject.Find(x + "-" + y + "M (1)");
        //             square.name=x + "-" + y;
        //             square0.name=x + "-" + y + " (1)";
        //         }
        //     }
        //     check = true;
        // }
    }
}
