using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Enums;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Models
{
    //класс, реализующий интерфейс модели заказа
    public class Order : IOrderModel
    {
        //методы set сделали приватными, чтобы исключить неразрешённые манипуляции
        public int Id { get; private set; }

		public int ClientId { get; private set; }

		public int? ImplementerId { get; private set; }

		public int ManufactureId { get; private set; }

        public int Count { get; private set; }

        public double Sum { get; private set; }

        public OrderStatus Status { get; private set; }

        public DateTime DateCreate { get; private set; } = DateTime.Now;

        public DateTime? DateImplement { get; private set; }

        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }

            return new Order()
            {
                Id = model.Id,
                ManufactureId = model.ManufactureId,
                ClientId = model.ClientId,
                ImplementerId = model.ImplementerId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement
            };
        }

        //метод изменения существующего объекта
        public void Update(OrderBindingModel? model)
        {
            if(model == null)
            {
                return;
            }

            Status = model.Status;
            DateImplement = model.DateImplement;
        }

        //метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureId = ManufactureId,
            ClientId = ClientId,
			ImplementerId = ImplementerId,
			Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };
	}
}
