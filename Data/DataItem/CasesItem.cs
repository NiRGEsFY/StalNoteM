using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalNoteM.Data.DataItem
{
    public class CaseItem
    {

        public CaseItem() { }
        public CaseItem(Data.DataItem.Item item) 
        {
            ItemId = item.Id;
            Name = item.Name.Lines.Ru;
            Type = item.Category.Split('/').First();
            Rank = JsonConvert.DeserializeObject<Data.DataItem.Key>(item.InfoBlocks[0].Elements[0].Value.ToString()).Lines.Ru;
            Class = JsonConvert.DeserializeObject<Data.DataItem.Key>(item.InfoBlocks[0].Elements[1].Value.ToString()).Lines.Ru;
            Weight = (double)item.InfoBlocks[0].Elements[2].Value;
            CaseType = item.InfoBlocks[2].Text?.Lines.Ru ?? null;
            foreach (var temp in item.InfoBlocks[3].Elements)
            {
                switch (temp.Name.Lines.Ru) 
                {
                    case "Внутренняя защита":
                        InnerProtection = (double)temp.Value;
                        break;
                    case "Эффективность":
                        Effectiveness = (double)temp.Value;
                        break;
                    case "Вместимость":
                        Capacity = (int)((double)temp.Value);
                        break;
                }

            }
            if (item.InfoBlocks[4].Elements != null)
            {
                foreach (var temp in item.InfoBlocks[4].Elements)
                {
                    switch (temp.Name.Lines.Ru)
                    {
                        case "Температура":
                            Temperature = (double)temp.Value;
                            break;
                        case "Переносимый вес":
                            CarryWeight = (double)temp.Value;
                            break;
                        case "Биологическое заражение":
                            BiologicalInfection = (double)temp.Value;
                            break;
                        case "Радиация":
                            Radiation = (double)temp.Value;
                            break;
                        default:
                            Console.WriteLine("No element");
                            break;
                    }

                }
            }
            else
            {
                Description = item.InfoBlocks[4].Text.Lines.Ru ?? null;
            }
        }

        [Display(Name = "Id")]
        public int Id { get; set; }

        //+
        [Display(Name = "Stalcraft Id")]
        [MaxLength(20)]
        public string ItemId { get; set; }

        //+
        [Display(Name = "Тип")]
        [MaxLength(50)]
        public string Type { get; set; }

        //+
        [Display(Name = "Тип Контейнера")]
        [MaxLength(50)]
        public string? CaseType { get; set; }

        //+
        [Display(Name = "Название")]
        [MaxLength(50)]
        public string Name { get; set; }

        //+
        [Display(Name = "Ранг")]
        [MaxLength(50)]
        public string Rank { get; set; }

        //+
        [Display(Name = "Класс")]
        [MaxLength(50)]
        public string Class { get; set; }
        
        //+
        [Display(Name = "Вес")]
        public double Weight { get; set; }


        [Display(Name = "Внутренняя защита")]
        public double InnerProtection { get; set; }


        [Display(Name = "Эффективность")]
        public double Effectiveness { get; set; }


        [Display(Name = "Вместимость")]
        public int Capacity { get; set; }

        [Display(Name = "Переносимый вес")]
        public double CarryWeight { get; set; }

        [Display(Name = "Температура")]
        public double Temperature { get; set; }


        [Display(Name = "Биологическое заражение")]
        public double BiologicalInfection { get; set; }


        [Display(Name = "Радиация")]
        public double Radiation { get; set; }


        [Display(Name = "Описание")]
        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
