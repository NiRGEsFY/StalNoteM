using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalNoteM.Data.DataItem
{
    public class ArmorItem
    {
        public ArmorItem() { }
        public ArmorItem(Data.DataItem.Item item)
        {
            ItemId = item.Id;
            Name = item.Name.Lines.Ru;
            Type = item.Category.Split('/').First();
            SubType = item.Category.Split('/').Last();
            Rank = JsonConvert.DeserializeObject<Data.DataItem.Key>(item.InfoBlocks[0].Elements[0].Value.ToString()).Lines.Ru;
            Class = JsonConvert.DeserializeObject<Data.DataItem.Key>(item.InfoBlocks[0].Elements[1].Value.ToString()).Lines.Ru;
            Weight = (double)item.InfoBlocks[0].Elements[2].Value;
            foreach (var desc in item.InfoBlocks)
            {
                switch (desc.Title.Lines.Ru)
                {
                    case "Совместимые рюкзаки":
                        CompatibleBackpacks = desc.Text.Lines.Ru;
                        break;
                    case "Совместимые контейнеры":
                        CompatibleContainers = desc.Text.Lines.Ru;
                        break;
                    case "Особенности":
                        Features = desc.Elements[0].Text.Lines.Ru;
                        break;
                }
            }
            Description = item.InfoBlocks.Last().Text.Lines.Ru;
            if (item.InfoBlocks[2].Elements.Count > 0)
            {
                foreach (var character in item.InfoBlocks[2].Elements)
                {
                    switch (character.Name.Lines.Ru)
                    {
                        case "Скорость передвижения":
                            MoveSpeed = (double)character.Value;
                            break;
                        case "Переносимый вес":
                            CarryWeight = (double)character.Value;
                            break;
                        case "Выносливость":
                            Stamina = (double)character.Value;
                            break;
                        case "Стойкость":
                            Stability = (double)character.Value;
                            break;
                        case "Восстановление выносливости":
                            StaminaRegeneration = (double)character.Value;
                            break;
                        case "Кровотечение":
                            Bleeding = (double)character.Value;
                            break;
                        case "Периодическое лечение":
                            PeriodicHealing = (double)character.Value;
                            break;
                    }
                }
            }
            foreach (var character in item.InfoBlocks[3].Elements)
            {
                switch (character.Name.Lines.Ru)
                {
                    case "Пулестойкость":
                        BulletResistance = (double)character.Value;
                        break;
                    case "Защита от разрыва":
                        LacerationProtection = (double)character.Value;
                        break;
                    case "Защита от взрыва":
                        ExplosionProtection = (double)character.Value;
                        break;
                    case "Электрозащита":
                        ResistanceToElectricity = (double)character.Value;
                        break;
                    case "Защита от огня":
                        ResistanceToFire = (double)character.Value;
                        break;
                    case "Химзащита":
                        ResistanceToChemicals = (double)character.Value;
                        break;
                    case "Защита от радиации":
                        RadiationProtection = (double)character.Value;
                        break;
                    case "Защита от температуры":
                        ThermalProtection = (double)character.Value;
                        break;
                    case "Защита от биозаражения":
                        BioinfectionProtection = (double)character.Value;
                        break;
                    case "Защита от пси-излучения":
                        PsyProtection = (double)character.Value;
                        break;
                    case "Защита от кровотечения":
                        BleedingProtection = (double)character.Value;
                        break;
                }
            }
        }


        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "Stalcraft Id")]
        [MaxLength(20)]
        public string ItemId { get; set; }


        [Display(Name = "Main Type")]
        [MaxLength(30)]
        public string Type { get; set; }


        [Display(Name = "Sub Type")]
        [MaxLength(30)]
        public string SubType { get; set; }

        
        [Display(Name = "Заточка")]
        public int Pottential { get; set; }

        
        [Display(Name = "Название")]
        [MaxLength(100)]
        public string Name { get; set; }

        
        [Display(Name = "Ранг")]
        [MaxLength(30)]
        public string Rank { get; set; }

        
        [Display(Name = "Класс")]
        [MaxLength(30)]
        public string Class { get; set; }

        
        [Display(Name = "Вес")]
        public double Weight { get; set; }


        [Display(Name = "Периодическое лечение")]
        public double PeriodicHealing { get; set; }


        [Display(Name = "Кровотечение")]
        public double Bleeding { get; set; }


        [Display(Name = "Стойкость")]
        public double Stability { get; set; }


        [Display(Name = "Восстановление выносливости")]
        public double StaminaRegeneration { get; set; }


        [Display(Name = "Выносливость")]
        public double Stamina { get; set; }


        [Display(Name = "Скорость передвижения")]
        public double MoveSpeed { get; set; }


        [Display(Name = "Переносимый вес")]
        public double CarryWeight { get; set; }


        [Display(Name = "Пулестойкость")]
        public double BulletResistance { get; set; }


        [Display(Name = "Защита от разрыва")]
        public double LacerationProtection { get; set; }


        [Display(Name = "Защита от взрыва")]
        public double ExplosionProtection { get; set; }


        [Display(Name = "Электрозащита")]
        public double ResistanceToElectricity { get; set; }


        [Display(Name = "Защита от огня")]
        public double ResistanceToFire { get; set; }


        [Display(Name = "Химзащита")]
        public double ResistanceToChemicals { get; set; }


        [Display(Name = "Защита от радиации")]
        public double RadiationProtection { get; set; }


        [Display(Name = "Защита от температуры")]
        public double ThermalProtection { get; set; }


        [Display(Name = "Защита от биозаражения")]
        public double BioinfectionProtection { get; set; }


        [Display(Name = "Защита от пси-излучения")]
        public double PsyProtection { get; set; }


        [Display(Name = "Защита от кровотечения")]
        public double BleedingProtection { get; set; }


        [Display(Name = "Совместимые рюкзаки")]
        [MaxLength(40)]
        public string? CompatibleBackpacks { get; set; }


        [Display(Name = "Совместимые контейнеры")]
        [MaxLength(40)]
        public string? CompatibleContainers {get;set;}


        [Display(Name = "Особенности")]
        [MaxLength(500)]
        public string? Features { get; set; }


        [Display(Name = "Описание")]
        [MaxLength(1000)]
        public string? Description {  get; set; }
    }
}
