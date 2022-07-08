using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    //mapping class
   public class PlayerStatistic
    {
        //TODO: Composite PK in Fluent API
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public byte ScoredGoals { get; set; }

        public byte Assists { get; set; }
        public byte MinutesPlayed { get; set; }
    }
}
