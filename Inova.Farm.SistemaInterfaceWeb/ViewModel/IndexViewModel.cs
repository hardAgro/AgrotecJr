using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inova.Farm.SistemaInterfaceWeb.ViewModel
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.StagesMonitored = new List<ProductionStage>();
        }

        public IndexViewModel(string name, string fruitName, int numberOfDifferentStages, 
             List<int> irrigation, List<int> soilCondition, List<string>stage, string farmName) : this()
        {
            string soilConditionCategory, irrigationCategory;
            this.Name = name;
            this.FruitPlanted = fruitName;
            this.FarmName = farmName;
            this.NumberOfDifferentProductionProcess = numberOfDifferentStages;
            for (int i = 0; i < numberOfDifferentStages; i++)
            {
                if (soilCondition[i] == 0 && stage[i].Equals("cultivo"))
                {
                    soilConditionCategory = "seco";
                    irrigationCategory = "alta";

                }
                else if (soilCondition[i] == 0 && stage[i].Equals("produção"))
                {
                    soilConditionCategory = "entre seco e úmido";
                    irrigationCategory = "pouca demanda";
                }
                else if (soilCondition[i] == 1 && stage[i].Equals("cultivo"))
                {
                    soilConditionCategory = "pouco úmido";
                    irrigationCategory = "regular";

                }
                else if (soilCondition[i] == 1 && stage[i].Equals("produção"))
                {
                    soilConditionCategory = "pouco úmido";
                    irrigationCategory = "regular";
                }
                else if(soilCondition[i]==2 && stage[i].Equals("produção"))
                {
                    soilConditionCategory = "saturado";
                    irrigationCategory = "nenhuma";
                }
                else if(soilCondition[i] == 2 && stage[i].Equals("cultivo"))
                {
                    soilConditionCategory = "saturado";
                    irrigationCategory = "nenhuma";
                }
                else
                {
                    throw new Exception("Houve um problema com os dados calculados.");
                }
                this.StagesMonitored.Add(new ProductionStage(soilConditionCategory, irrigationCategory, stage[i]));
            }

        }
        
        
        // informações básicas sobre o usuário
        public string Name { get; set; }
        public string FruitPlanted { get; set; }
        public string FarmName { get; set; }
        //para indicar quantas fases fenológicas diferentes o produtor possui simultaneamente para entender os níveis diferentes de irrigação necessárias;
        public int NumberOfDifferentProductionProcess { get; set; } 
        public IList<ProductionStage> StagesMonitored { get; set; }

        
        public class ProductionStage
        {
            public ProductionStage(string soilCondition, string irrigationMeasure, string stage)
            {
                this.SoilCondition = soilCondition;
                this.IrrigationMeasure = irrigationMeasure;
                this.Stage = stage;
            }
            public string SoilCondition { get; set; }
            public string IrrigationMeasure { get; set; }
            public string Stage { get; set; }
        }

    }
}