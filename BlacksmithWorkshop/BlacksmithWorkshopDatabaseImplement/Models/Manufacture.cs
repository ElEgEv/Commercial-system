using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class Manufacture : IManufactureModel
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string ManufactureName { get; set; } = string.Empty;

        [Required]
        [DataMember]
        public double Price { get; set; }

        public Dictionary<int, (IWorkPieceModel, int)>? _manufactureWorkPieces = null;

        //это поле не будет "мапиться" в бд
        [NotMapped]
        [DataMember]
        public Dictionary<int, (IWorkPieceModel, int)> ManufactureWorkPieces
        {
            get
            {
                if(_manufactureWorkPieces == null)
                {
                    _manufactureWorkPieces = WorkPieces
                        .ToDictionary(recPC => recPC.WorkPieceId, recPC => (recPC.WorkPiece as IWorkPieceModel, recPC.Count));
                }

                return _manufactureWorkPieces;
            }
        }

        //для реализации связи многие ко многим с заготовками
        [ForeignKey("ManufactureId")]
        public virtual List<ManufactureWorkPiece> WorkPieces { get; set; } = new();

        [ForeignKey("ManufactureId")]
        public virtual List<Order> Orders { get; set; } = new();

        [ForeignKey("ManufactureId")]
        public virtual List<ShopManufacture> Shops { get; set; } = new();

        public static Manufacture Create(BlacksmithWorkshopDatabase context, ManufactureBindingModel model)
        {
            return new Manufacture()
            {
                Id = model.Id,
                ManufactureName = model.ManufactureName,
                Price = model.Price,
                WorkPieces = model.ManufactureWorkPieces.Select(x => new ManufactureWorkPiece
                {
                    WorkPiece = context.WorkPieces.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
            };
        }

        public void Update(ManufactureBindingModel model)
        {
            ManufactureName = model.ManufactureName;
            Price = model.Price;
        }

        public ManufactureViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureName = ManufactureName,
            Price = Price,
            ManufactureWorkPieces = ManufactureWorkPieces
        };

        public void UpdateWorkPieces(BlacksmithWorkshopDatabase context, ManufactureBindingModel model)
        {
            var manufactureWorkPieces = context.ManufactureWorkPieces.Where(rec => rec.ManufactureId == model.Id).ToList();

            if (manufactureWorkPieces != null && manufactureWorkPieces.Count > 0)
            { 
                // удалили те, которых нет в модели
                context.ManufactureWorkPieces.RemoveRange(manufactureWorkPieces.Where(rec => !model.ManufactureWorkPieces.ContainsKey(rec.ManufactureId)));
                context.SaveChanges();

                // обновили количество у существующих записей
                foreach (var updateManufacture in manufactureWorkPieces)
                {
                    updateManufacture.Count = model.ManufactureWorkPieces[updateManufacture.ManufactureId].Item2;
                    model.ManufactureWorkPieces.Remove(updateManufacture.ManufactureId);
                }

                context.SaveChanges();
            }

            var manufacture = context.Manufactures.First(x => x.Id == Id);

            foreach (var mwp in model.ManufactureWorkPieces)
            {
                context.ManufactureWorkPieces.Add(new ManufactureWorkPiece
                {
                    Manufacture = manufacture,
                    WorkPiece = context.WorkPieces.First(x => x.Id == mwp.Key),
                    Count = mwp.Value.Item2
                });

                context.SaveChanges();
            }

            _manufactureWorkPieces = null;
        }
    }
}
