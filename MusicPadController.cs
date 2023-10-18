using UnityEngine;
using UnityEngine.UI;

public class MusicPadController : MonoBehaviour
{
    public Color blackColor = Color.black;
    public Color cyanColor = Color.cyan;

    private int numRows = 10;
    private int numCols = 16;
    private Image[,] squares;

    void Start()
    {
        CreateSquares();
    }

    void CreateSquares()
    {
        squares = new Image[numCols, numRows];

        for (int x = 0; x < numCols; x++)
        {
            for (int y = 0; y < numRows; y++)
            {

            }
        }
    }
}
