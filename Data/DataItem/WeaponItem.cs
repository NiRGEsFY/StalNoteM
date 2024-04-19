using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalNoteM.Data.DataItem
{
    public class WeaponItem
    {
        public WeaponItem() { }
        public WeaponItem(Data.DataItem.Item item)
        {
            ItemId = item.Id;
            Name = item.Name.Lines.Ru;
            Type = item.Category.Split('/').First();
            SubType = item.Category.Split('/').Last();
            Rank = JsonConvert.DeserializeObject<Data.DataItem.Key>(item.InfoBlocks[0].Elements[0].Value.ToString()).Lines.Ru;
            Class = JsonConvert.DeserializeObject<Data.DataItem.Key>(item.InfoBlocks[0].Elements[1].Value.ToString()).Lines.Ru;
            foreach (var tempItem in item.InfoBlocks[0].Elements)
            {
                if (tempItem.Name.Lines.Ru == "Вес")
                {
                    Weight = (double)tempItem.Value;
                }
            }
            foreach (var character in item.InfoBlocks[2].Elements)
            {
                switch (character.Name.Lines.Ru)
                {
                    case null:
                        AmmoType = JsonConvert.DeserializeObject<Data.DataItem.Key>(item.InfoBlocks[2].Elements[0].Value.ToString()).Lines.Ru;
                        break;
                    case "Урон":
                        Damage = (double)character.Value;
                        break;
                    case "Объем магазина":
                        MagazineCapacity = (double)character.Value;
                        break;
                    case "Максимальная дистанция":
                        MaxDistance = (double)character.Value;
                        break;
                    case "Скорострельность":
                        RateOfFire = (double)character.Value;
                        break;
                    case "Перезарядка":
                        Reload = (double)character.Value;
                        break;
                    case "Тактическая перезарядка":
                        TacticalReload = (double)character.Value;
                        break;
                    case "Разброс":
                        Spread = (double)character.Value;
                        break;
                    case "Разброс от бедра":
                        HipFireSpread = (double)character.Value;
                        break;
                    case "Вертикальная отдача":
                        VerticalRecoil = (double)character.Value;
                        break;
                    case "Горизонтальная отдача":
                        HorizontalRecoil = (double)character.Value;
                        break;
                    case "Доставание":
                        DrawTime = (double)character.Value;
                        break;
                    case "Прицеливание":
                        AimingTime = (double)character.Value;
                        break;
                }
            }
            foreach (var desc in item.InfoBlocks)
            {
                switch (desc.Title.Lines.Ru)
                {
                    case "Дополнительные характеристики":
                        foreach (var tempItem in desc.Elements)
                        {
                            switch (tempItem.Name.Lines.Ru)
                            {
                                case "Останавливающее действие":
                                    StoppingPower = (double)tempItem.Value;
                                    break;
                                case "Бронебойность":
                                    ArmorPenetration = (double)tempItem.Value;
                                    break;
                                case "Кровотечение":
                                    Bleeding = (double)tempItem.Value;
                                    break;

                            }
                        }
                        break;
                    case "Множитель урона":
                        foreach (var tempItem in desc.Elements)
                        {
                            string tempInput = tempItem.Text.Lines.Ru;
                            switch (tempInput.Split(' ')[2])
                            {
                                case "голову:":
                                    DamageModifierHeadshot = double.Parse(tempInput.Split('х').Last());
                                    break;
                                case "мутантам:":
                                    DamageToMutants = double.Parse(tempInput.Split('х').Last());
                                    break;
                                case "конечностям:":
                                    DamageModifierLimb = double.Parse(tempInput.Split('х').Last());
                                    break;
                            }
                        }
                        break;
                    case "Особенности":
                        foreach (var tempItem in desc.Elements)
                        {
                            switch (tempItem.Name.Lines.Ru)
                            {
                                case "Урон от разрыва":
                                case "Морозный урон":
                                case "Чистый урон":
                                case "Огненный урон":
                                case "Электрический урон":
                                    Features += $"{tempItem.Name.Lines.Ru} {tempItem.Value}|";
                                    continue;
                                
                            }
                            Features += $"{tempItem.Text.Lines.Ru}|";
                        }
                        break;
                }
                switch (desc.Type)
                {
                    case "damage":
                        StartDamage = desc.StartDamage;
                        EndDamage = desc.EndDamage;
                        DamageDecreaseEnd = desc.DamageDecreaseEnd;
                        DamageDecreaseStart = desc.DamageDecreaseStart;
                        break;
                }
            }
            try
            {
                Description = item.InfoBlocks?.Last().Text?.Lines.Ru ?? null;
            }
            catch { }
        }


        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "Stalcraft Id")]
        [MaxLength(30)]
        public string ItemId { get; set; }


        [Display(Name = "Main Type")]
        [MaxLength(50)]
        public string Type { get; set; }


        [Display(Name = "Sub Type")]
        [MaxLength(50)]
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


        [Display(Name = "Тип патрона")]
        [MaxLength(20)]
        public string? AmmoType { get; set; }


        [Display(Name = "Урон")]
        public double Damage { get; set; }


        [Display(Name = "")]
        public double StartDamage { get; set; }


        [Display(Name = "")]
        public double EndDamage { get; set; }


        [Display(Name = "")]
        public double DamageDecreaseStart { get; set; }


        [Display(Name = "")]
        public double DamageDecreaseEnd { get; set; }


        [Display(Name = "Объем магазина")]
        public double MagazineCapacity { get; set; }


        [Display(Name = "Максимальная дистанция")]
        public double MaxDistance { get; set; }


        [Display(Name = "Скорострельность")]
        public double RateOfFire { get; set; }


        [Display(Name = "Перезарядка")]
        public double Reload { get; set; }


        [Display(Name = "Тактическая перезарядка")]
        public double TacticalReload { get; set; }


        [Display(Name = "Разброс")]
        public double Spread { get; set; }


        [Display(Name = "Разброс от бедра")]
        public double HipFireSpread { get; set; }


        [Display(Name = "Вертикальная отдача")]
        public double VerticalRecoil { get; set; }


        [Display(Name = "Горизонтальная отдача")]
        public double HorizontalRecoil { get; set; }


        [Display(Name = "Доставание")]
        public double DrawTime { get; set; }


        [Display(Name = "Прицеливание")]
        public double AimingTime { get; set; }


        [Display(Name = "Урон в голову")]
        public double DamageModifierHeadshot { get; set; }


        [Display(Name = "Урон по конечностям")]
        public double DamageModifierLimb { get; set; }


        [Display(Name= "Урон по мутантам")]
        public double DamageToMutants { get; set; }


        [Display(Name = "Описание")]
        [MaxLength(1000)]
        public string? Description { get; set; }


        [Display(Name = "Кровотечение")]
        public double Bleeding { get; set; }


        [Display(Name="Бронебойность")]
        public double ArmorPenetration { get;set; }


        [Display(Name = "Останавливающее действие")]
        public double StoppingPower { get; set; }


        [Display(Name="Особенности")]
        [MaxLength(200)]
        public string? Features { get; set; }
    }
}
