using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    // Player
    class Player
    {
        // Player name
        private string playerName;
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    playerName = value;
                }
                else
                {
                    System.Console.WriteLine($"{playerName} is to short, Try again.");
                }
            }
        }

        // Frag count
        public int Frags = 0;

        // Death count
        public int Deaths = 0;

        // Total damage
        private float health;
        public float Health { get; set; }
        // Total damage (Health: Will display remaining amount of health they have taken after the total amount of damage they have taken))
        public void TotalDamage(float damageTaken)
        {
            health -= damageTaken;
            Health = health;
        }

        // Score (Determine by subtracting their death count from the their frag count)
        public int Score
        {
            get
            {
                return Frags - Deaths;
            }
        }

        // Overall stats
        public void OverallStatistics()
        {
            System.Console.WriteLine($"Name: {playerName}");
            System.Console.WriteLine($"Frags: {Frags}");
            System.Console.WriteLine($"Deaths: {Deaths}");
            System.Console.WriteLine($"Total Damage: {health}");
            System.Console.WriteLine($"Score : {Score}");
            System.Console.WriteLine(" ");
        }
    }
}
