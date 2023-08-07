using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement.Implements
{
    //реализация интерфейса хранилища заготовок
    public class WorkPieceStorage : IWorkPieceStorage
    {
        private readonly DataFileSingleton source;

        public WorkPieceStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<WorkPieceViewModel> GetFullList()
        {
            return source.WorkPieces.Select(x => x.GetViewModel).ToList();
        }

        public List<WorkPieceViewModel> GetFilteredList(WorkPieceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.WorkPieceName))
            {
                return new();
            }

            return source.WorkPieces.Where(x => x.WorkPieceName.Contains(model.WorkPieceName)).Select(x => x.GetViewModel).ToList();
        }

        public WorkPieceViewModel? GetElement(WorkPieceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.WorkPieceName) && !model.Id.HasValue)
            {
                return null;
            }

            return source.WorkPieces.FirstOrDefault(x => (!string.IsNullOrEmpty(model.WorkPieceName) && x.WorkPieceName == model.WorkPieceName)
                || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public WorkPieceViewModel? Insert(WorkPieceBindingModel model)
        {
            model.Id = source.WorkPieces.Count > 0 ? source.WorkPieces.Max(x => x.Id) + 1 : 1;

            var newWorkPiece = WorkPiece.Create(model);
            
            if (newWorkPiece == null)
            {
                return null;
            }

            source.WorkPieces.Add(newWorkPiece);
            source.SaveWorkPieces();

            return newWorkPiece.GetViewModel;
        }

        public WorkPieceViewModel? Update(WorkPieceBindingModel model)
        {
            var workPiece = source.WorkPieces.FirstOrDefault(x => x.Id == model.Id);
            
            if (workPiece == null)
            {
                return null;
            }

            workPiece.Update(model);
            source.SaveWorkPieces();

            return workPiece.GetViewModel;
        }

        public WorkPieceViewModel? Delete(WorkPieceBindingModel model)
        {
            var element = source.WorkPieces.FirstOrDefault(x => x.Id == model.Id);
            
            if (element != null)
            {
                source.WorkPieces.Remove(element);
                source.SaveWorkPieces();

                return element.GetViewModel;
            }

            return null;
        }
    }
}
