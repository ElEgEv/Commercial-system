using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement
{
    //класс для списков, в которых будет храниться информация при работе приложения
    public class DataListSingleton
    {
        private static DataListSingleton? _instance;

        //список для хранения заготовок
        public List<WorkPiece> WorkPieces { get; set; }

        //список для хранения изделий
        public List<Manufacture> Manufactures { get; set; }

        //список для хранения заказов
        public List<Order> Orders { get; set; }

        //список для хранения Магазинов
        public List<Shop> Shops { get; set; }

        //список для хранения Магазинов
        public List<Client> Clients { get; set; }

		//список для хранения исполнителей
		public List<Implementer> Implementers { get; set; }

		//список для хранения писем
		public List<MessageInfo> MessageInfos { get; set; }


		public DataListSingleton()
        {
            WorkPieces = new List<WorkPiece>();
            Manufactures = new List<Manufacture>();
            Orders = new List<Order>();
            Shops = new List<Shop>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfos = new List<MessageInfo>();
        }

        public static DataListSingleton GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataListSingleton();
            }

            return _instance;
        }
    }
}
