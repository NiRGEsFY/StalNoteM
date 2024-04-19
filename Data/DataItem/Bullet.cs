using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StalNoteM.Data.DataItem
{
    public class Bullet
    {
        public Bullet() { }
        public Bullet(Data.DataItem.Item item) 
        {
            ItemId = item.Id;
            Name = item.Name.Lines.Ru;
            Type = item.Category.Split('/').First();
            Class = JsonConvert.DeserializeObject<Data.DataItem.Key>(item.InfoBlocks[0].Elements[0].Value.ToString()).Lines.Ru;
            Weight = (double)item.InfoBlocks[0].Elements[1].Value;
            SubType = item.InfoBlocks[2].Elements[0].Text.Lines.Ru;


            foreach (var temp in item.InfoBlocks[3].Elements)
            {
                switch (temp.Name.Lines.Ru)
                {
                    case "Урон":
                        Damage = (double)temp.Value;
                        break;
                    case "Кровотечение":
                        Bleeding = (double)temp.Value;
                        break;
                    case "Бронебойность":
                        ArmorPenetration = (double)temp.Value;
                        break;
                    case "Разброс":
                        Spread = (double)temp.Value;
                        break;
                    case "Останавливающее действие":
                        StoppingPower = (double)temp.Value;
                        break;
                    case "Горение":
                        Burning = (double)temp.Value;
                        break;
                    case "Число поражающих эл-тов":
                        NumberOfProjectiles = (double)temp.Value;
                        break;
                    default:
                        Console.WriteLine("пропустил");
                        break;
                }
            }


            if (item.Name.Lines.Ru.Contains("12 калибр"))
            {
                AmmoType = "12 калибр";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("12.7"))
            {
                AmmoType = "12.7";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("Аккумулятор"))
            {
                AmmoType = "Аккумулятор";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("7.62"))
            {
                AmmoType = "7.62";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("9 мм"))
            {
                AmmoType = "9 мм";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("9х39"))
            {
                AmmoType = "9х39";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("5.45"))
            {
                AmmoType = "5.45";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("5.56"))
            {
                AmmoType = "5.56";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("Горючая смесь") || item.Name.Lines.Ru.Contains("горючей смесью"))
            {
                AmmoType = "Горючая смесь";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("Крупный калибр") || item.Name.Lines.Ru.Contains("Крупнокалиберный"))
            {
                AmmoType = "Крупный калибр";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("Выстрел РПГ"))
            {
                AmmoType = "Выстрел РПГ";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("40 мм"))
            {
                AmmoType = "40 мм";
                return;
            }
            else if (item.Name.Lines.Ru.Contains("10 мм"))
            {
                AmmoType = "10 мм";
            }
        }

        [Display(Name = "Id")]
        public int Id { get; set; }

        //+
        [Display(Name = "Stalcraft Id")]
        [MaxLength(20)]
        public string ItemId { get; set; }


        [Display(Name = "Разброс")]
        public double Spread {  get; set; }


        [Display(Name = "Урон")]
        public double Damage { get; set; }


        [Display(Name = "Число поражающих эл-тов")]
        public double NumberOfProjectiles {  get; set; }


        [Display(Name = "Под Тип")]
        [MaxLength(30)]
        public string SubType { get; set; }
        //+
        [Display(Name = "Тип")]
        [MaxLength(30)]
        public string Type { get; set; }

        //+
        [Display(Name = "Название")]
        [MaxLength(50)]
        public string Name { get; set; }

        //+
        [Display(Name = "Класс")]
        [MaxLength(30)]
        public string Class { get; set; }

        //+
        [Display(Name = "Вес")]
        public double Weight { get; set; }


        [Display(Name = "Тип Патрона")]
        [MaxLength(30)]
        public string AmmoType { get; set; }


        [Display(Name = "Бронебойность")]
        public double ArmorPenetration { get; set; }


        [Display(Name = "Кровотечение")]
        public double Bleeding {  get; set; }


        [Display(Name = "Останавливающее действие")]
        public double StoppingPower {  get; set; }


        [Display(Name = "Горение")]
        public double Burning { get; set; }
    }
}
