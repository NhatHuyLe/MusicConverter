using UnityEngine;
using System.IO;

public class DrawingController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private bool isDrawing = false;
    public int[,] digital_pic;
    void Start()
    {
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }

        if (isDrawing)
        {
            Draw();
        }
    }

    void StartDrawing()
    {
        isDrawing = true;
        //lineRenderer.positionCount = 0;
    }

    void StopDrawing()
    {
        isDrawing = false;
    }

    void Draw()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Perform a raycast to check if the mouse position intersects with the blackboard's collider
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Blackboard"))
        {
            // Only draw if the raycast hits the blackboard
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePosition);
        }
    }

    //clear the drawing
    public void ClearDrawing()
    {
        lineRenderer.positionCount = 0;
        StopDrawing();
    }

    public void CaptureDrawing()
    {
        RenderTexture renderTexture = new RenderTexture(900, 600, 24);
        Camera.main.targetTexture = renderTexture;
        Texture2D drawingTexture = new Texture2D(675, 450, TextureFormat.RGB24, false);
        Camera.main.Render();
        RenderTexture.active = renderTexture;
        drawingTexture.ReadPixels(new Rect(111.5f, 43, 675, 450), 0, 0);
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // Save the drawing texture as a PNG file
        byte[] bytes = drawingTexture.EncodeToPNG();
        string filePath = Path.Combine(Application.dataPath,"Sample.png"); 
        //if the file exists, change the name until it doesn't
        int i = 0;
        while (File.Exists(filePath))
        {
            i++;
            filePath = Path.Combine(Application.dataPath,"Sample" + i + ".png");
        }
        File.WriteAllBytes(filePath, bytes);
        string file_name = "Sample";
        if (i > 0)
        {
            file_name += i;
        }
        if (File.Exists(filePath))
        {
            Debug.Log("File exists: "+filePath);
        }
        Debug.Log("Filename is "+file_name);
        digital_pic = processPicture(filePath);
        GameObject dataholder= GameObject.Find("Canvas");
        dataholder.GetComponent<DataHolder>().setDigitalPic(digital_pic);  
    }

    public int[,] processPicture(string path)
    {
        // Read the file as bytes.
        byte[] imageBytes = File.ReadAllBytes(path);

        // Create a new Texture2D and load the image from the bytes.
        Texture2D originalImage = new Texture2D(675,450); // You can set the dimensions as needed.
        originalImage.LoadImage(imageBytes);
        
        int squareWidth = originalImage.width / 16;
        int squareHeight = originalImage.height / 10;

        Texture2D gridTexture = new Texture2D(16, 10);

        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Color squareColor = CalculateSquareColor(originalImage, x * squareWidth, y * squareHeight, squareWidth, squareHeight);
                gridTexture.SetPixel(x, y, squareColor);
            }
        }

        gridTexture.Apply();

        //save in a 2d array size 16x10 with 0 being black and 1 being not black
        int[,] grid = new int[16, 10];
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Color squareColor = gridTexture.GetPixel(x, y);
                if (squareColor == Color.black)
                {
                    grid[x, y] = 0;
                }
                else
                {
                    grid[x, y] = 1;
                }
            }
        }
        return grid;
    }

    Color CalculateSquareColor(Texture2D originalImage, int startX, int startY, int width, int height)
    {
        float totalR = 0f;
        float totalG = 0f;
        float totalB = 0f;

        for (int x = startX; x < startX + width; x++)
        {
            for (int y = startY; y < startY + height; y++)
            {
                Color pixelColor = originalImage.GetPixel(x, y);
                totalR += pixelColor.r;
                totalG += pixelColor.g;
                totalB += pixelColor.b;
            }
        }

        // You can define a threshold value to determine when a square should be black or light blue
        int threshold = 150; // Adjust the threshold as needed (0-255*3 range)

        //if it is larger than the threshold, return cyan, else return black
        if (totalR + totalG + totalB > threshold)
        {
            return Color.cyan; // You can adjust the color as needed
        }
        else
        {
            return Color.black;
        }
    }
}
