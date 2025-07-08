using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    // Supongamos que tienes una grilla de Nodos ya creada.
    public Node[,] grid; 

    // --- IMPLEMENTACIÓN DE BFS ---
    public List<Node> FindReachableNodes_BFS(Node startNode)
    {
        List<Node> reachableNodes = new List<Node>();
        Queue<Node> queue = new Queue<Node>();
        HashSet<Node> visitedNodes = new HashSet<Node>(); // Para no visitar nodos repetidos

        queue.Enqueue(startNode);
        visitedNodes.Add(startNode);

        while (queue.Count > 0)
        {
            Node currentNode = queue.Dequeue(); // Saca el primer nodo de la cola
            reachableNodes.Add(currentNode);

            foreach (Node neighbor in currentNode.neighbors)
            {
                // Si el vecino es caminable y no ha sido visitado...
                if (neighbor.isWalkable && !visitedNodes.Contains(neighbor))
                {
                    visitedNodes.Add(neighbor);
                    queue.Enqueue(neighbor); // ...lo añade a la cola para visitarlo después.
                }
            }
        }
        return reachableNodes;
    }

    // --- IMPLEMENTACIÓN DE DFS ---
    public List<Node> FindReachableNodes_DFS(Node startNode)
    {
        List<Node> reachableNodes = new List<Node>();
        Stack<Node> stack = new Stack<Node>();
        HashSet<Node> visitedNodes = new HashSet<Node>();

        stack.Push(startNode);

        while (stack.Count > 0)
        {
            Node currentNode = stack.Pop(); // Saca el último nodo de la pila

            if (!currentNode.isWalkable || visitedNodes.Contains(currentNode))
            {
                continue; // Si es un muro o ya lo visitamos, lo ignoramos.
            }

            visitedNodes.Add(currentNode);
            reachableNodes.Add(currentNode);

            foreach (Node neighbor in currentNode.neighbors)
            {
                // Añade a la pila a todos los vecinos no visitados.
                if (!visitedNodes.Contains(neighbor))
                {
                    stack.Push(neighbor);
                }
            }
        }
        return reachableNodes;
    }
}