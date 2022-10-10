using System;

namespace CovidMeetsHogwarts
{
    public class Edge
    {
        // Attributes
        private (Node source, Node destination) endpoints; // source and destination
        // can be interchanged because we're working with undirected graphs
        
        // Methods
        // - constructor
        public Edge(Node source, Node destination)
        {
            this.endpoints = (source, destination);
        }
        
        // - getters
        public (Node source, Node destination) GetEndpoints()
        {
            return endpoints;
        }

        // - == and != operators overload
        public static bool operator== (Edge edge1, Edge edge2)
        {
            if (edge1 == null && edge2 == null)
            {
                return true;
            }
            else
            {
                return (edge1.GetEndpoints() == edge2.GetEndpoints() || (edge1.GetEndpoints().destination == edge2.GetEndpoints().source && edge2.GetEndpoints().destination == edge1.GetEndpoints().source)) ;
            }
        }

        public static bool operator!= (Edge edge1, Edge edge2)
        {
            return !(edge1 == edge2);
        }

        /// <summary>
        /// represent edge by its end points in DOT language
        /// </summary>
        /// <returns>string describing this edge in DOT language followed by a newline character</returns>
        public override string ToString()
        {
            string s = "\t" + this.GetEndpoints().source + " -- " + this.GetEndpoints().destination + ";\n";
            return s;
        }
    }
}