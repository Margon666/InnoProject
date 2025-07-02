using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

// ДОДЕЛАТЬ БАГ С НАЧАЛЬНОЙ КОМНАТОЙ (сделано)
// Сделать спавн комнат
// Сделать спавн коридоров
public class RoomGeneration : MonoBehaviour
{
    public RoomType[][] roomGeneration = new RoomType[10][];
    public GameObject roomStart;
    public GameObject roomEnd;
    public GameObject roomHeal;
    public GameObject roomSimple;
    public GameObject corridor;
    public GameObject player;
    public float xLenthRooms = 5f;

    public float yLenthRooms = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            roomGeneration[i] = new RoomType[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // создание поля для генерации карты
        }

        int countRooms = Random.Range(7, 25); // генерация количетсва комнат
        roomGeneration[4][4] = RoomType.Start; // создагие первой(стартовой) комнаты
        int x = 4; // координаты сейчас по x
        int y = 4; // координаты сейчас по y
        //Debug.Log(roomGeneration[4][4]);
        for (int _cnt = 1; _cnt < countRooms; _cnt++)
        {
            Direction direction = (Direction)Random.Range(1, 5);
            if (direction == Direction.West)
            {
                while (x > -1 && roomGeneration[x][y] != RoomType.Null)
                {
                    x--;
                }

                if (x > -1)
                {
                    if (x == 4 && y == 4)
                    {
                        //Debug.Log(1);
                    }

                    roomGeneration[x][y] = RoomType.Simple;
                }
                else
                {
                    x = 0;
                    countRooms++;
                }
            }

            if (direction == Direction.North)
            {
                while (y > -1 && roomGeneration[x][y] != RoomType.Null)
                {
                    y--;
                }

                if (y > -1)
                {
                    if (x == 4 && y == 4)
                    {
                        //Debug.Log(2);
                    }

                    roomGeneration[x][y] = RoomType.Simple;
                }
                else
                {
                    y = 0;
                    countRooms++;
                }
            }

            if (direction == Direction.South)
            {
                while (x < 10 && roomGeneration[x][y] != RoomType.Null)
                {
                    x++;
                }

                if (x < 10)
                {
                    if (x == 4 && y == 4)
                    {
                        //Debug.Log(3);
                    }

                    roomGeneration[x][y] = RoomType.Simple;
                }
                else
                {
                    x = 9;
                    countRooms++;
                }
            }

            if (direction == Direction.North)
            {
                while (y < 10 && roomGeneration[x][y] != RoomType.Null)
                {
                    y++;
                }

                if (y < 10)
                {
                    if (x == 4 && y == 4)
                    {
                        //Debug.Log(4);
                    }

                    roomGeneration[x][y] = RoomType.Simple;
                }
                else
                {
                    y = 9;
                    countRooms++;
                }
            }
        }

        //
        // for (int _x = 0; _x < 10; _x++)
        // {
        //     string str = _x.ToString()+") ";
        //     for (int _y=0; _y < 10; _y++)
        //     {
        //         str+=roomGeneration[_x][_y].ToString()+" ";
        //     }
        //     //Debug.Log(str);
        // }
        //Debug.Log(roomGeneration[4][4]);
        roomGeneration = getFarHealRoom(roomGeneration);
        for (int _x = 0; _x < 10; _x++)
        {
            string str = _x.ToString() + ") ";
            for (int _y = 0; _y < 10; _y++)
            {
                str += ((int)roomGeneration[_x][_y]).ToString() + " ";
            }

            //Debug.Log(str);
        }

        roomGen(roomGeneration);
        corridorGen(roomGeneration);
    }

    // Update is called once per frame
    void Update()
    {
    }

    RoomType[][] getFarHealRoom(RoomType[][] roomGeneration)
    {
        int x = 4;
        int y = 4;
        bool[,] pos = new bool[10, 10];
        Queue<Vector3Int> queue = new Queue<Vector3Int>();
        queue.Enqueue(new Vector3Int(x, y, 0));
        int maxWay = 0;
        Vector2Int FarRoom = new Vector2Int(0, 0);
        while (queue.Count > 0)
        {
            bool check = false;
            Vector3Int Vertex = queue.Dequeue();
            pos[Vertex.x, Vertex.y] = true;
            if (Vertex.x > 0 && !pos[Vertex.x - 1, Vertex.y] && roomGeneration[Vertex.x - 1][Vertex.y] != RoomType.Null)
            {
                queue.Enqueue(new Vector3Int(Vertex.x - 1, Vertex.y, Vertex.z + 1));
                check = true;
            }

            if (Vertex.x < 9 && !pos[Vertex.x + 1, Vertex.y] && roomGeneration[Vertex.x + 1][Vertex.y] != RoomType.Null)
            {
                queue.Enqueue(new Vector3Int(Vertex.x + 1, Vertex.y, Vertex.z + 1));
                check = true;
            }

            if (Vertex.y > 0 && !pos[Vertex.x, Vertex.y - 1] && roomGeneration[Vertex.x][Vertex.y - 1] != RoomType.Null)
            {
                queue.Enqueue(new Vector3Int(Vertex.x, Vertex.y - 1, Vertex.z + 1));
                check = true;
            }

            if (Vertex.y < 9 && !pos[Vertex.x, Vertex.y + 1] && roomGeneration[Vertex.x][Vertex.y + 1] != RoomType.Null)
            {
                queue.Enqueue(new Vector3Int(Vertex.x, Vertex.y + 1, Vertex.z + 1));
                check = true;
            }

            if (Vertex.z > maxWay)
            {
                maxWay = Vertex.z;
                FarRoom.x = Vertex.x;
                FarRoom.y = Vertex.y;
                check = true;
            }

            if (!check && Vertex.z > 2 && roomGeneration[Vertex.x][Vertex.y] != RoomType.Null)
            {
                roomGeneration[Vertex.x][Vertex.y] = RoomType.Heal;
            }
        }

        roomGeneration[FarRoom.x][FarRoom.y] = RoomType.End;
        return roomGeneration;
    }

    void roomGen(RoomType[][] roomGeneration)
    {
        float xPos = 0 - xLenthRooms * 4;
        for (int i = 0; i < 10; i++)
        {
            float yPos = 0 - yLenthRooms * 4;
            for (int j = 0; j < 10; j++)
            {
                if (roomGeneration[i][j] == RoomType.Start)
                {
                    Instantiate(roomStart, new Vector3(xPos, 0, yPos), Quaternion.identity);
                }

                if (roomGeneration[i][j] == RoomType.Simple)
                {
                    GameObject _roomSimple = Instantiate(roomSimple, new Vector3(xPos, 0, yPos), Quaternion.identity);
                    _roomSimple.GetComponent<Fight>().player = player;
                }

                if (roomGeneration[i][j] == RoomType.End)
                {
                    Instantiate(roomEnd, new Vector3(xPos, 0, yPos), Quaternion.identity);
                }

                if (roomGeneration[i][j] == RoomType.Heal)
                {
                    Instantiate(roomHeal, new Vector3(xPos, 0, yPos), Quaternion.identity);
                }

                yPos += yLenthRooms;
            }

            xPos += xLenthRooms;
        }
    }

    void corridorGen(RoomType[][] roomGeneration)
    {
        float xPos = 0 - xLenthRooms * 4;
        for (int i = 0; i < 10; i++)
        {
            float yPos = 0 - yLenthRooms * 4;
            for (int j = 0; j < 10; j++)
            {
                if (roomGeneration[i][j] != RoomType.Null)
                {
                    if (i < 9 && roomGeneration[i + 1][j] != RoomType.Null)
                    {
                        Instantiate(corridor, new Vector3(xPos + xLenthRooms / 2, 0, yPos), Quaternion.Euler(0, 90, 0));
                    }

                    if (j < 9 && roomGeneration[i][j + 1] != RoomType.Null)
                    {
                        Instantiate(corridor, new Vector3(xPos, 0, yPos + yLenthRooms / 2), Quaternion.identity);
                    }
                }

                yPos += yLenthRooms;
            }

            xPos += xLenthRooms;
        }
    }
}


public enum Direction
{
    North = 1,
    South = 2,
    East = 3,
    West = 4
}

public enum RoomType
{
    Null = 0,
    Simple = 1,
    Start = 2,
    End = 3,
    Heal = 4
}