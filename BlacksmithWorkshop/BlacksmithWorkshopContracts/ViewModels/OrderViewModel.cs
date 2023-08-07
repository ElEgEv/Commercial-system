using BlacksmithWorkshopContracts.Attributes;
using BlacksmithWorkshopDataModels.Enums;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
    //класс для отображения пользователю информации о заказах
    public class OrderViewModel : IOrderModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(visible: false)]
        public int ClientId { get; set; }

        [Column(visible: false)]
        public int? ImplementerId { get; set; }

        [Column(visible: false)]
        public int ManufactureId { get; set; }

        [Column(title: "ФИО клиента", width: 150)]
        public string ClientFIO { get; set; } = string.Empty;

        [Column(title: "Изделие", width: 150)]
        public string ManufactureName { get; set; } = string.Empty;

        [Column(title: "ФИО исполнителя", width: 150)]
		public string ImplementerFIO { get; set; } = string.Empty;

        [Column(title: "Количество", width: 150)]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 150, format: "0.00")]
        public double Sum { get; set; }

        [Column(title: "Статус", width: 150)]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;

        [Column(title: "Дата создания", width: 150, format: "D")]
        public DateTime DateCreate { get; set; } = DateTime.Now;

        [Column(title: "Дата выполнения", width: 150, format: "f")]
        public DateTime? DateImplement { get; set; }
	}
}
