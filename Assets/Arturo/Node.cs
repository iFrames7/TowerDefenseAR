using System.Collections.Generic;
using UnityEngine;

// Clase que representa una casilla en la grilla.
public class Node : MonoBehaviour
{
    public Vector2Int gridPosition; // Posición en la grilla (ej: (0,1))
    public bool isWalkable;         // ¿Es un muro o es caminable?
    public List<Node> neighbors;    // Lista de nodos vecinos
    
    // Constructor
    public Node(int x, int y, bool walkable)
    {
        gridPosition = new Vector2Int(x, y);
        isWalkable = walkable;
        neighbors = new List<Node>();
    }
}