using BlacksmithWorkshopContracts.Attributes;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
    public class ClientViewModel : IClientModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "ФИО клиента", width: 150)]
        public string ClientFIO { get; set; } = string.Empty;

        [Column(title: "Логие (эл. почта)", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Email { get; set; } = string.Empty;

        [Column(title: "Пароль", width: 150)]
        public string Password { get; set; } = string.Empty;

    }
}
