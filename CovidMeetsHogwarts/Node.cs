using System;
using System.Collections.Generic;

namespace CovidMeetsHogwarts
{
    public class Node
    {
        // Attributes
        private string label; // spot's/node's name
        private List<Human> humans; // list of humans currently at this spot/node
        private List<Node> neighbors; // list of neighboring nodes (there exists a direct edge)

        // Methods
        // - constructor
        public Node(string label)
        {
            this.label = label;
        }
        
        // - getters
        public string GetLabel()
        {
            return label;
        }

        public List<Human> GetHumans()
        {
            return humans;
        }

        public List<Node> GetNeighbors()
        {
            return neighbors;
        }

        // - == and != operators overload
        public static bool operator== (Node node1, Node node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }
            else
            {
                return (node1.GetLabel() == node2.GetLabel());
            }
        }

        public static bool operator!= (Node node1, Node node2)
        {
            return node1.label != node2.label;
        }

        /// <summary>
        /// count amount of humans of given 'sir' at this node/spot.
        /// </summary>
        /// <param name="sir">type of SIR to count</param>
        /// <returns>number of humans of type 'sir'</returns>
        public int GetSIRCount(Human.SIR sir)
        {
            return humans.Count;
        }
        
        /// <summary>
        /// represent node by label.
        /// </summary>
        /// <returns>label of node</returns>
        public override string ToString()
        {
            return label;
        }

        /// <summary>
        /// translate node in dot language so it could be used in generated DOT file
        /// with desired format. 
        /// </summary>
        /// <returns>string of dot language that represents this node</returns>
        public string Format()
        {
            int susceptible = GetSIRCount(Human.SIR.SUSCEPTIBLE);
            int infectious = GetSIRCount(Human.SIR.INFECTIOUS);
            int removed = GetSIRCount(Human.SIR.REMOVED);
            return string.Format("\t{0}\n" +
                                 "\t[\n" +
                                 "\t\tshape = none\n" +
                                 "\t\tlabel = <<table border=\"0\" cellspacing=\"0\">\n" +
                                 "\t\t\t    <tr><td port=\"port1\" border=\"1\">{0}</td></tr>\n" +
                                 "\t\t\t    <tr><td port=\"port2\" border=\"1\" bgcolor=\"lightskyblue\">susceptible: {1}</td></tr>]\n" +
                                 "\t\t\t    <tr><td port=\"port3\" border=\"1\" bgcolor=\"tomato\">infectious: {2}</td></tr>\n" +
                                 "\t\t\t    <tr><td port=\"port4\" border=\"1\" bgcolor=\"gray80\">removed: {3}</td></tr>\n" +
                                 "\t\t        </table>>\n" +
                                 "\t]\n", label, susceptible, infectious, removed);
        }
    }
}