using System;
using System.Collections.Generic;

namespace CovidMeetsHogwarts
{
    public class PandemicSimulator
    {
        public static List<Human> infectious;
        
        /// <summary>
        /// initialize pandemic by infecting a random human by the corona virus in given location.
        /// </summary>
        /// <param name="location">location where the pandemic is simulated</param>
        public static void InitializePandemic(Location location)
        {
            Random rnd = new Random();
            Human infect = location.GetHumans()[rnd.Next(location.GetHumans().Count)];
            bool b = false;

            bool hyg = infect.GetHygiene()*100 == rnd.Next(100);
            bool social = infect.GetSocialDistance()*100 == rnd.Next(100);

            if (hyg == true)
            {
                b = true;
            }
            else if(social == true)
            {
                b = rnd.Next(1) == 1;
            }

            if (b)
            {
                infect.SetVirus(new Virus("Covid-19", 0.6, 3, 14));
                infect.SetSir(Human.SIR.INFECTIOUS);
                infectious.Add(infect);
            }
        }

        /// <summary>
        /// move/travel given human to a neighboring spot according to their
        /// travelling rate.
        /// </summary>
        /// <param name="human">human to move (or not)</param>
        static void MoveAround(Human human)
        {
            Random rnd = new Random();
            bool b = human.GetTravellingRate() * 100 == rnd.Next(100);

            if (b)
            {
                Node currentSpot = human.GetCurrentSpot();
                Node destination = currentSpot.GetNeighbors()[rnd.Next(currentSpot.GetNeighbors().Count)];
                human.SetCurrentSpot(destination);

                List<Human> rh = new List<Human> { };
                foreach (Human hmn in currentSpot.GetHumans())
                {
                    if (hmn != human)
                    {
                        rh.Add(hmn);
                    }
                }

                destination.GetHumans().Add(human);
            }
        }

        /// <summary>
        /// try to infect susceptible humans at the transmitter's spot.
        /// the following factors are taken into account:
        ///     - the virus' infection range
        ///     - the virus's transmission rate
        ///     - the average hygiene between the transmitter and the susceptible human
        ///     - the distance between the transmitter and the susceptible human (also average of social distance)
        /// </summary>
        /// <param name="transmitter">the human carrying the virus</param>
        /// <param name="justGotInfected">the list of humans to update when someone gets infected</param>
        static void InfectOthers(Human transmitter, List<Human> justGotInfected)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// update pandemic by a unit of time at given location.
        ///     - infectious humans will infect around them
        ///     - some of the infectious humans will heal/die if enough days have passed
        ///     - some humans will travel to a neighboring spot
        /// the infectious list should be updated as well
        /// </summary>
        /// <param name="location">location where the pandemic is simulated</param>
        /// <returns>return number of infectious humans at this round</returns>
        public static int UpdatePandemic(Location location)
        {
            throw new NotImplementedException();
        }
    }
}