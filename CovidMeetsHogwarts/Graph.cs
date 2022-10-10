using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.WebSockets;

namespace CovidMeetsHogwarts
{
    public class Graph // undirected graph
    {
        // Attributes
        private string name;
        private List<Node> nodes; // spots
        private List<Edge> edges; // paths
        
        // Methods
        // - constructor
        public Graph(string name)
        {
            this.name = name;
        }

        // - getters
        public string GetName()
        {
            return name;
        }

        public List<Node> GetNodes()
        {
            return nodes;
        }

        public List<Edge> GetEdges()
        {
            return edges;
        }

        /// <summary>
        /// try to create and add node to this graph.
        /// if a node with the same label already exists, then return existing node.
        /// return created node otherwise.
        /// </summary>
        /// <param name="label">label of the node to add</param>
        /// <returns>created/existing node</returns>
        Node AddNode(string label)
        {
            List<Node> listofnodes = GetNodes();
            for (int i = 0; i < listofnodes.Count; i++)
            {
                if (label == listofnodes[i].GetLabel())
                {
                    return listofnodes[i];
                }
            }
            Node nodeN = new Node(label);
            nodes.Add(nodeN);

            return nodeN;
        }

        /// <summary>
        /// try to create and add edge to this graph.
        /// if this edge already exists, then return false because no edges were added.
        /// return true otherwise.
        /// </summary>
        /// <param name="source">source node of the edge to add</param>
        /// <param name="destination">destination node of the edge to add</param>
        /// <returns>a boolean of whether an edge was added or not</returns>
        bool AddEdge(Node source, Node destination)
        {
                List<Edge> listofEdges = this.GetEdges();
                for (int i = 0; i < listofEdges.Count; i++)
                {
                    if ((source, destination) == listofEdges[i].GetEndpoints())
                    {
                        return false;
                    }
                }

                Edge edgeN = new Edge(source, destination);
                edges.Add(edgeN);

                return true;
        }

        /// <summary>
        /// extract the graph's name of the first line in a DOT file. (first line of a graph declaration)
        /// 
        /// example of a first line: "graph Epita {".
        /// In this example, the string "Epita" should be returned.
        /// </summary>
        /// <param name="firstLine">first line of a DOT file</param>
        /// <returns>the name of the graph</returns>
        public static string ExtractNameFromLine(string firstLine)
        {
            return firstLine.Split(' ')[1];
        }
        
        /// <summary>
        /// extract nodes and edge from a given edge line in DOT file and add them
        /// to given 'graph'.
        /// The format of edgeLine's string is the same as the ToString() method
        /// in Edge.cs without the newline character.
        /// 
        /// example of edgeLine: "    VA302 -- VA303;".
        /// In this example, the nodes of respective labels "VA302" and "VA303" as well
        /// as the edge linking those two should be added to the graph.
        /// </summary>
        /// <param name="edgeLine">string in DOT language describing an edge</param>
        /// <param name="graph">graph to update</param>
        /// <exception cref="Exception">an exception should be raised if the edge already exists</exception>
        public static void UpdateGraphFromLine(string edgeLine, Graph graph)
        {
            string labelA = edgeLine.Split('\t')[0].Split(" -- ")[0];
            string labelB = edgeLine.Split('\t')[0].Split(" -- ")[1].Split(";")[0];
            Node nodeA = graph.AddNode("labelA");
            Node nodeB = graph.AddNode("labelB");

            bool add_edge = graph.AddEdge(nodeA, nodeB);
            if (!add_edge)
            {
                throw new Exception("Cannot add Edge between nodes : Edge already defined!");
            }
        }
        
        /// <summary>
        /// generate graph from file written in simple DOT language.
        /// </summary>
        /// <param name="filepath">path of file in DOT language</param>
        /// <returns>created graph</returns>
        public static Graph FromFile(string filepath)
        {
            string[] allLines = File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
            Graph graph1 = new Graph(ExtractNameFromLine(allLines[0]));
            for (int i = 1; i < allLines.Length-1; i++)
            {
                UpdateGraphFromLine(allLines[i], graph1);
            }

            return graph1;
        }
    }
}