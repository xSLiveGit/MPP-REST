using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientREST
{
    public class Match : IHasId<Int32>
    {
        public Int32 id;
        public String team2;
        public String team1;
        public String stage;
        public Double price;
        public Int32 tickets;

        
        public Int32 getId()
        {
            return this.id;
        }

        public Int32 getTicktes()
        {
            return this.tickets;
        }

        public void setTickets(Int32 tickets)
        {
            this.tickets = tickets;
        }

        public Double getPrice()
        {
            return this.price;
        }

        public void setPrice(Double price)
        {
            this.price = price;
        }

        public String getStage()
        {
            return this.stage;
        }

        public void setStage(String stage)
        {
            this.stage = stage;
        }

        public void setId(Int32 id)
        {
            this.id = id;
        }


        public String getTeam1()
        {
            return this.team1;
        }

        public void setTeam1(String team1)
        {
            this.team1 = team1;
        }

        public String getTeam2()
        {
            return this.team2;
        }

        public void setTeam2(String team2)
        {
            this.team2 = team2;
        }



        /// <summary>
        /// throw new EntityArgumentException() if  value < 0
        /// </summary>


        //        public String GetTicketsString()
        //        {
        //            if(Tickets < 0){
        //                throw new EntityArgumentException("The number of tickets must be >=0.");
        //            }
        //            if(Tickets == 0)
        //             return "SOLD OUT";
        //        return Tickets.ToString();
        //        }
        /// <summary>
        /// Construct an match entity. Constraint : tickets >= 0
        /// </summary>
        /// <param name="team1"> home team</param>
        /// <param name="team2"> visitator team</param>
        /// <param name="stage"> competition stage</param>
        /// <param name="tickets"> numbers of tickets remaining at this match</param>
        /// <param name="price">price for one place at match</param>
        public Match(string team1, string team2, string stage, int tickets, double price) : this(0, team1, team2, stage, tickets, price)
        {

        }

        /// <summary>
        /// Construct an match entity. Constraint : tickets >= 0 && id >= 0
        /// </summary>
        /// <param name="id"> unique key</param>
        /// <param name="team1"> home team</param>
        /// <param name="team2"> visitator team</param>
        /// <param name="stage"> competition stage</param>
        /// <param name="tickets"> numbers of tickets remaining at this match</param>
        /// <param name="price">price for one place at match</param>
        public Match(int id, string team1, string team2, string stage, int tickets, double price)
        {
            this.tickets = tickets;
            this.id = id;
            this.team1 = team1;
            this.team2 = team2;
            this.stage = stage;
            this.price = price;
        }

        protected bool Equals(Match other)
        {
            return id == other.id && string.Equals(team2, other.team2) && string.Equals(team1, other.team1) && string.Equals(stage, other.stage) && price.Equals(other.price) && tickets == other.tickets;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Match) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = id;
                hashCode = (hashCode * 397) ^ (team2 != null ? team2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (team1 != null ? team1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (stage != null ? stage.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ price.GetHashCode();
                hashCode = (hashCode * 397) ^ tickets;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
