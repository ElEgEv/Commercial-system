﻿using BlacksmithWorkshopDataModels.Enums;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BindingModels
{
    //реализация сущности "Заказ"
    public class OrderBindingModel : IOrderModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

		public int? ImplementerId { get; set; }

		public int ManufactureId { get; set; }

        public int Count { get; set; }

        public double Sum { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public DateTime? DateImplement { get; set; }
    }
}
