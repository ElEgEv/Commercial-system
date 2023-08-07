using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Implements
{
    public class WorkPieceStorage : IWorkPieceStorage
    {
        public List<WorkPieceViewModel> GetFullList()
        {
            using var context = new BlacksmithWorkshopDatabase();

            return context.WorkPieces
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<WorkPieceViewModel> GetFilteredList(WorkPieceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.WorkPieceName))
            {
                return new();
            }

            using var context = new BlacksmithWorkshopDatabase();

            return context.WorkPieces
                    .Where(x => x.WorkPieceName.Contains(model.WorkPieceName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public WorkPieceViewModel? GetElement(WorkPieceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.WorkPieceName) && !model.Id.HasValue)
            {
                return null;
            }

            using var context = new BlacksmithWorkshopDatabase();

            return context.WorkPieces
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.WorkPieceName) && x.WorkPieceName == model.WorkPieceName) ||
                                        (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public WorkPieceViewModel? Insert(WorkPieceBindingModel model)
        {
            var newWorkPiece = WorkPiece.Create(model);

            if (newWorkPiece == null)
            {
                return null;
            }

            using var context = new BlacksmithWorkshopDatabase();
            context.WorkPieces.Add(newWorkPiece);
            context.SaveChanges();

            return newWorkPiece.GetViewModel;
        }

        public WorkPieceViewModel? Update(WorkPieceBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            var workPiece = context.WorkPieces.FirstOrDefault(x => x.Id == model.Id);

            if (workPiece == null)
            {
                return null;
            }

            workPiece.Update(model);
            context.SaveChanges();

            return workPiece.GetViewModel;
        }

        public WorkPieceViewModel? Delete(WorkPieceBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            var element = context.WorkPieces.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.WorkPieces.Remove(element);
                context.SaveChanges();

                return element.GetViewModel;
            }

            return null;
        }
    }
}
