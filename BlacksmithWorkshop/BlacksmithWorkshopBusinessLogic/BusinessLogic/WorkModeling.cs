using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogic
{
	public class WorkModeling : IWorkProcess
	{
		private readonly ILogger _logger;

		private readonly Random _rnd;

		private IOrderLogic? _orderLogic;

		public WorkModeling(ILogger<WorkModeling> logger)
		{
			_logger = logger;
			_rnd = new Random(1000);
		}

		public void DoWork(IImplementerLogic implementerLogic, IOrderLogic orderLogic)
		{
			_orderLogic = orderLogic;
			var implementers = implementerLogic.ReadList(null);

			if (implementers == null)
			{
				_logger.LogWarning("DoWork. Implementers is null");
				return;
			}

			var orders = _orderLogic.ReadList(new() { Status = OrderStatus.Принят });
            if (orders == null)
            {
                _logger.LogWarning("DoWork. Orders is null or empty");
                return;
            }

            _logger.LogDebug("DoWork for {Count} orders", orders.Count);

			foreach (var implementer in implementers)
			{
				Task.Run(() => WorkerWorkAsync(implementer, orders));
			}
		}

		// Иммитация работы исполнителя
		private async Task WorkerWorkAsync(ImplementerViewModel implementer, List<OrderViewModel> orders)
		{
			if (_orderLogic == null || implementer == null)
			{
				return;
			}

            await Task.Run(() =>
            {
                try
                {
                    var runOrder = _orderLogic.ReadList(new OrderSearchModel
                    {
                        ImplementerId = implementer.Id,
                        Status = OrderStatus.Ожидание
                    });

                    if (runOrder == null)
                    {
                        return;
                    }

					foreach(var order in runOrder)
                    {
                        _logger.LogDebug("DoWork. Worker {Id} finish order {Order}", implementer.Id, order.Id);
                        _orderLogic.FinishOrder(new OrderBindingModel
                        {
                            Id = order.Id
                        });
                        // отдыхаем
                        //Thread.Sleep(implementer.Qualification * _rnd.Next(10, 100));
                    }
                }
                // заказа может не быть, просто игнорируем ошибку
                catch (InvalidOperationException ex)
                {
                    _logger.LogWarning(ex, "Error try get work");
                }
                // а может возникнуть иная ошибка, тогда просто заканчиваем выполнение имитации
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while do work");
                    throw;
                }
            });

            await RunOrderInWork(implementer);

			await Task.Run(() =>
			{
				foreach (var order in orders)
				{
					try
					{
						_logger.LogDebug("DoWork. Worker {Id} try get order {Order}", implementer.Id, order.Id);

						// пытаемся назначить заказ на исполнителя
						_orderLogic.TakeOrderInWork(new OrderBindingModel
						{
							Id = order.Id,
							ImplementerId = implementer.Id
						});

						// делаем работу
						Thread.Sleep(implementer.WorkExperience * order.Count);

						_logger.LogDebug("DoWork. Worker {Id} finish order {Order}", implementer.Id, order.Id);

						_orderLogic.FinishOrder(new OrderBindingModel
						{
							Id = order.Id,
						});

						// отдыхаем
						Thread.Sleep(implementer.Qualification);
					}
					// кто-то мог уже перехватить заказ, игнорируем ошибку
					catch (InvalidOperationException ex)
					{
						_logger.LogWarning(ex, "Error try get work");
					}
					// заканчиваем выполнение имитации в случае иной ошибки
					catch (Exception ex)
					{
						_logger.LogError(ex, "Error while do work");
						throw;
					}
				}
			});
		}

		//Ищем заказ, которые уже в работе (вдруг исполнителя прервали)
		private async Task RunOrderInWork(ImplementerViewModel implementer)
		{
			if (_orderLogic == null || implementer == null)
			{
				return;
			}

			try
			{
				var runOrder = await Task.Run(() => _orderLogic.ReadElement(new OrderSearchModel
				{
					ImplementerId = implementer.Id,
					Status = OrderStatus.Выполняется
				}));

				if (runOrder == null)
				{
					return;
				}

				_logger.LogDebug("DoWork. Worker {Id} back to order {Order}", implementer.Id, runOrder.Id);

				// доделываем работу
				Thread.Sleep(implementer.WorkExperience * runOrder.Count);

				_logger.LogDebug("DoWork. Worker {Id} finish order {Order}", implementer.Id, runOrder.Id);

				_orderLogic.FinishOrder(new OrderBindingModel
				{
					Id = runOrder.Id
				});

				// отдыхаем
				Thread.Sleep(implementer.Qualification);
			}
			// заказа может не быть, просто игнорируем ошибку
			catch (InvalidOperationException ex)
			{
				_logger.LogWarning(ex, "Error try get work");
			}
			// а может возникнуть иная ошибка, тогда просто заканчиваем выполнение имитации
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while do work");
				throw;
			}
		}
    }
}
