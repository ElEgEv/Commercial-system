using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Models
{
    //реализация интерфейса модели заготовки
    public class WorkPiece : IWorkPieceModel
    {
        //методы set делаем приватным, чтобы исключить неразрешённые манипуляции
        public int Id { get; private set; }

        public string WorkPieceName { get; private set; } = string.Empty;

        public double Cost { get; private set; }

        //метод для создания объекта от класса-компонента на основе класса-BindingModel
        public static WorkPiece? Create(WorkPieceBindingModel? model)
        {
            if(model == null)
            {
                return null;
            }

            return new WorkPiece()
            {
                Id = model.Id,
                WorkPieceName = model.WorkPieceName,
                Cost = model.Cost
            };
        }

        //метод изменения существующего объекта
        public void Update(WorkPieceBindingModel? model)
        {
            if(model == null)
            {
                return;
            }

            WorkPieceName = model.WorkPieceName;
            Cost = model.Cost;
        }

        //метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
        public WorkPieceViewModel GetViewModel => new()
        {
            Id = Id,
            WorkPieceName = WorkPieceName,
            Cost = Cost
        };
    }
}
