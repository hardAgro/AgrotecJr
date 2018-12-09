using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inova.Farm.Domain
{
    public class CurrentProduction
    {
        public int Id { get; set; }
        public string FruitName { get; set; }
        public int CurrentPhaseId { get; set; }
        public virtual ProductionPhase CurrentPhase { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
