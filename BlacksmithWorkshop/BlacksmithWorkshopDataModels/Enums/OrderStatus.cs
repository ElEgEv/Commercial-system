using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Enums
{
    //статус заказа
    public enum OrderStatus
    {
        Неизвестен = -1,

        Принят = 0,

        Выполняется = 1,

        Готов = 2,

        Выдан = 3,

        Ожидание = 4
    }
}