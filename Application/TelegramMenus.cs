﻿using Microsoft.EntityFrameworkCore;
using StalNoteM.Data.Users;
using Telegram.Bot.Types.ReplyMarkups;

namespace StalNoteM.Application
{
    public class TelegramMenus
    {
        public static IReplyMarkup StartMenu()
        {
            var keyBoard = new ReplyKeyboardMarkup(new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("Аукционная ищейка (разраб)"), new KeyboardButton("Профиль статс (не раб.)") },
                    new List<KeyboardButton>{ new KeyboardButton("Привилегии"), new KeyboardButton("Жалобы/Предложения") }
                });
            keyBoard.IsPersistent = true;
            keyBoard.ResizeKeyboard = true;
            return keyBoard;
        }
        public static IReplyMarkup AuctionHunter()
        {
            var keyBoard = new ReplyKeyboardMarkup(new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("Добавить ищейку"), new KeyboardButton("Удалить ищейку") },
                    new List<KeyboardButton>{ new KeyboardButton("Изменить цену ищейки"), new KeyboardButton("График цен") },
                    new List<KeyboardButton>{ new KeyboardButton("Мои ищейки") }
                });
            keyBoard.IsPersistent = true;
            keyBoard.ResizeKeyboard = true;
            return keyBoard;
        }
        public static IReplyMarkup AddHunter(List<UserItem> items)
        {
            var sendMenuPart = new List<List<InlineKeyboardButton>>();
            foreach (var item in items)
            {
                sendMenuPart.Add(new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"{item.Name}",
                                        callbackData: $"ДобИщ|{item.ItemId}")
                                });
            }
            sendMenuPart.Add(new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Отмена",
                                    callbackData: $"Отмена|Отмена"
                            )});
            var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
            return sendMenu;
        }

        public static IReplyMarkup ChoiceQualityArtefact(string itemId)
        {
            var sendMenuPart = new List<List<InlineKeyboardButton>>
            {
                new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"Обыч.",
                                        callbackData: $"ВыбКач|{itemId}|0")
                                },
                new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"Необыч.",
                                        callbackData: $"ВыбКач|{itemId}|1")
                                },
                new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"Особ.",
                                        callbackData: $"ВыбКач|{itemId}|2")
                                },
                new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"Ред.",
                                        callbackData: $"ВыбКач|{itemId}|3")
                                },
                new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"Искл.",
                                        callbackData: $"ВыбКач|{itemId}|4")
                                },
                new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"Лег.",
                                        callbackData: $"ВыбКач|{itemId}|5")
                                },
                new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Отмена",
                                    callbackData: $"Отмена|Отмена"
                            )}
            };

            var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
            return sendMenu;

        }
        public static IReplyMarkup RemoveItemMenu(Data.Users.User user)
        {
            var sendMenuPart = new List<List<InlineKeyboardButton>>();
            foreach (var item in user.UserItems)
            {
                sendMenuPart.Add(new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"{item.TakeName() ?? "Без имени"}",
                                        callbackData: $"УдИщ|{item.Id}")
                                });
            }
            sendMenuPart.Add(new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Отмена",
                                    callbackData: $"Отмена|Отмена"
                            )});
            var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
            return sendMenu;
        }
        public static IReplyMarkup ChangeHunterPrice(Data.Users.User user)
        {
            var sendMenuPart = new List<List<InlineKeyboardButton>>();
            foreach (var item in user.UserItems)
            {
                sendMenuPart.Add(new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"{item.TakeName() ?? "Без имени"}",
                                        callbackData: $"ИзмЦену|{item.Id}")
                                });
            }
            sendMenuPart.Add(new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Отмена",
                                    callbackData: $"Отмена|Отмена"
                            )});
            var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
            return sendMenu;
        }
        public static IReplyMarkup AllItemMenu(Data.Users.User user)
        {
            var sendMenuPart = new List<List<InlineKeyboardButton>>();
            foreach (var item in user.UserItems)
            {
                sendMenuPart.Add(new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"{item.TakeName() ?? "Без имени"}",
                                        callbackData: $"Отмена|Отмена")
                                });
            }
            sendMenuPart.Add(new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Закрыть",
                                    callbackData: $"Отмена|Отмена"
                            )});
            var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
            return sendMenu;
        }
        public static IReplyMarkup ChoiseItem(List<UserItem> items)
        {
            var sendMenuPart = new List<List<InlineKeyboardButton>>();
            foreach (var item in items)
            {
                sendMenuPart.Add(new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"{item.Name}",
                                        callbackData: $"ВыбВрем|{item.ItemId}")
                                });
            }
            sendMenuPart.Add(new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Отмена",
                                    callbackData: $"Отмена|Отмена"
                            )});
            var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
            return sendMenu;
        }
        public static IReplyMarkup ChoiseItemTime(string itemId,long chatId)
        {
            List<int> times = new List<int>() { 6, 12, 24, 48, 72, 168, 336, 672 };
            string roleName;
            using (var context = new ApplicationDbContext())
            {
                roleName = context.Users.Include(x => x.UserTelegram).Where(x => x.UserTelegram.ChatId == chatId).Include(x => x.Role).First().Role.Name;
            }
            switch (roleName) 
            {
                case "Новичек":
                    times = new List<int>() { 6 };
                    break;
                case "Бывалый":
                    times = new List<int>() { 6, 12, 24 };
                    break;
                case "Опытный":
                    times = new List<int>() { 6, 12, 24, 48, 72 };
                    break;
                case "Ветеран":
                    times = new List<int>() { 6, 12, 24, 48, 72, 168 };
                    break;
                case "Мастер":
                    times = new List<int>() { 6, 12, 24, 48, 72, 168, 336 };
                    break;
                case "Легенда":
                    times = new List<int>() { 6, 12, 24, 48, 72, 168, 336, 672 };
                    break;
                default:
                    times = new List<int>() { 6, 12, 24, 48, 72, 168, 336, 672 };
                    break;
            }

            var sendMenuPart = new List<List<InlineKeyboardButton>>();
            foreach (var time in times)
            {
                string output = string.Empty;
                if (time >= 24)
                {
                    switch (time / 24)
                    {
                        case 1:
                            output = $"За {time / 24} день";
                            break;
                        case 2:
                        case 3:
                            output = $"За {time / 24} дня";
                            break;
                        case 7:
                        case 14:
                        case 28:
                            output = $"За {time / 24} дней";
                            break;
                    }
                }
                else
                {
                    output = $"За {time} часов ";
                }

                sendMenuPart.Add(new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"{output}",
                                        callbackData: $"ОтпГраф|{itemId}|{time}")
                                });
            }
            sendMenuPart.Add(new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Отмена",
                                    callbackData: $"Отмена|Отмена"
                            )});
            var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
            return sendMenu;
        }
        public static IReplyMarkup PremiumMenus()
        {
            using (var context = new ApplicationDbContext())
            {
                List<string> items = context.Roles.Where(x => x.Name != "Разработчик").Select(x => x.Name).ToList();
                var sendMenuPart = new List<List<InlineKeyboardButton>>();
                foreach (var item in items)
                {
                    sendMenuPart.Add(new List<InlineKeyboardButton>
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        text: $"{item}",
                                        callbackData: $"ВывПрем|{item}")
                                });
                }
                sendMenuPart.Add(new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Отмена",
                                    callbackData: $"Отмена|Отмена"
                            )});
                var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
                return sendMenu;
            }
        }
        public static IReplyMarkup BuyPrem()
        {
            var sendMenuPart = new List<List<InlineKeyboardButton>>();
            sendMenuPart.Add(new List<InlineKeyboardButton>
            { 
                                    InlineKeyboardButton.WithUrl(
                                        text: $"Купить",
                                        url: $"https://web.telegram.org/a/#5167551861")
            });
            sendMenuPart.Add(new List<InlineKeyboardButton>()
                            {
                                InlineKeyboardButton.WithCallbackData(
                                    text: "Отмена",
                                    callbackData: $"Отмена|Отмена"
                            )});
            var sendMenu = new InlineKeyboardMarkup(sendMenuPart);
            return sendMenu;
        }
    }
}