using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Implements
{
    //класс, реализующий интерфейс хранилища заготовок
    public class WorkPieceStorage : IWorkPieceStorage
    {
        //поле для работы со списком заготовок
        private readonly DataListSingleton _source;

        //получение в конструкторе объекта DataListSingleton
        public WorkPieceStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        //получение полного списка заготовок
        public List<WorkPieceViewModel> GetFullList()
        {
            var result = new List<WorkPieceViewModel>();

            foreach(var workPiece in _source.WorkPieces)
            {
                result.Add(workPiece.GetViewModel);
            }

            return result;
        }

        //получение отфильтрованного списка заготовок
        public List<WorkPieceViewModel> GetFilteredList(WorkPieceSearchModel model)
        {
            var result = new List<WorkPieceViewModel>();

            if(string.IsNullOrEmpty(model.WorkPieceName))
            {
                return result;
            }

            foreach(var workPiece in _source.WorkPieces)
            {
                if (workPiece.WorkPieceName.Contains(model.WorkPieceName))
                {
                    result.Add(workPiece.GetViewModel);
                }
            }

            return result;
        }

        //получение элемента из списка заготовок
        public WorkPieceViewModel? GetElement(WorkPieceSearchModel model)
        {
            if(string.IsNullOrEmpty(model.WorkPieceName) && !model.Id.HasValue)
            {
                return null;
            }

            foreach(var workPiece in _source.WorkPieces)
            {
                if((!string.IsNullOrEmpty(model.WorkPieceName) && workPiece.WorkPieceName == model.WorkPieceName) ||
                    (model.Id.HasValue && workPiece.Id == model.Id))
                {
                    return workPiece.GetViewModel;
                }
            }

            return null;
        }

        //при создании заготовки определяем для него новый id: ищем max id и прибавляем к нему 1
        public WorkPieceViewModel? Insert(WorkPieceBindingModel model)
        {
            model.Id = 1;

            foreach(var workPiece in _source.WorkPieces)
            {
                if(model.Id <= workPiece.Id)
                {
                    model.Id = workPiece.Id + 1;
                }
            }

            var newWorkPiece = WorkPiece.Create(model);

            if(newWorkPiece == null)
            {
                return null;
            }

            _source.WorkPieces.Add(newWorkPiece);

            return newWorkPiece.GetViewModel;
        }

        //обновление заготовки
        public WorkPieceViewModel? Update(WorkPieceBindingModel model)
        {
            foreach(var workPiece in _source.WorkPieces)
            {
                if(workPiece.Id == model.Id)
                {
                    workPiece.Update(model);

                    return workPiece.GetViewModel;
                }
            }

            return null;
        }

        //удаление заготовки
        public WorkPieceViewModel? Delete(WorkPieceBindingModel model)
        {
            for(int i = 0; i < _source.WorkPieces.Count; ++i)
            {
                if (_source.WorkPieces[i].Id == model.Id)
                {
                    var element = _source.WorkPieces[i];
                    _source.WorkPieces.RemoveAt(i);

                    return element.GetViewModel;
                }
            }

            return null;
        }
    }
}
