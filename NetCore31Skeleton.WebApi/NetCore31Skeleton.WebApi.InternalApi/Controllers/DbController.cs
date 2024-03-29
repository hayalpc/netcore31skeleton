﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.Core.Enums;
using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        private readonly ITransactionBusiness transactionBusiness;
        private readonly IGenericLogger logger;

        public DbController(ITransactionBusiness transactionBusiness, IGenericLogger logger)
        {
            this.transactionBusiness = transactionBusiness;
            this.logger = logger;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            logger.Debug("selam Debug " + HttpContext.TraceIdentifier);

            var insert = transactionBusiness.Insert(new Transaction()
            {
                MerchantId = 1,
                ServiceId = 1,
                Msisdn = "5433379967",
                OperatorId = 1,
                Amount = 15.01m,
                Status = TransStatus.NEW,
                Item = "Test Item",

            });
            if (insert.Data is Transaction)
            {
                var tid = insert.Data.Id;
                logger.Info($"TxnId {tid}");

                var getTrans = transactionBusiness.GetByQuery(x => x.Status == TransStatus.NEW);
                if (getTrans.Data is Transaction)
                {
                    var transaction = getTrans.Data;
                    logger.Info($"TxnId{tid} {transaction.Id}");

                    transaction.Status = TransStatus.CHARGED;
                    transaction.ChargeDate = DateTime.Now;
                    transaction.RefundDate = DateTime.Now;
                    transaction.RefundSource = $"Test {tid}";
                    transaction.OperatorTransId = Guid.NewGuid().ToString("D");
                    transaction.OrderId = Guid.NewGuid().ToString("D");
                    transaction.UserIp = HttpContext.Connection.RemoteIpAddress + ":" + HttpContext.Connection.RemotePort;
                    transaction.UpdateTime = DateTime.Now;
                    transaction.UpdateUserId = -1;
                    transaction.Error = HttpContext.TraceIdentifier;

                    var result = transactionBusiness.Update(transaction);

                    logger.Debug(result);

                }
            }
            logger.Info("selam Info " + HttpContext.TraceIdentifier + " " + stopWatch.ElapsedMilliseconds + "ms");
            return Ok();
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            logger.Debug("selam Debug " + HttpContext.TraceIdentifier);

            var insert = await transactionBusiness.InsertAsync(new Transaction()
            {
                MerchantId = 1,
                ServiceId = 1,
                Msisdn = "5433379967",
                OperatorId = 1,
                Amount = 15.01m,
                Status = TransStatus.NEW,
                Item = "Test Item",

            });
            if (insert.Data is Transaction)
            {

                var tid = insert.Data.Id;
                logger.Info($"TxnId {tid}");

                var getTrans = await transactionBusiness.GetByQueryAsync(x => x.Status == TransStatus.NEW);
                if (getTrans.Data is Transaction)
                {
                    var transaction = getTrans.Data;
                    logger.Info($"TxnId{tid} {transaction.Id}");

                    transaction.Status = TransStatus.CHARGED;
                    transaction.ChargeDate = DateTime.Now;
                    transaction.RefundDate = DateTime.Now;
                    transaction.RefundSource = $"Test {tid}";
                    transaction.OperatorTransId = Guid.NewGuid().ToString("D");
                    transaction.OrderId = Guid.NewGuid().ToString("D");
                    transaction.UserIp = HttpContext.Connection.RemoteIpAddress + ":" + HttpContext.Connection.RemotePort;
                    transaction.UpdateTime = DateTime.Now;
                    transaction.UpdateUserId = -1;
                    transaction.Error = HttpContext.TraceIdentifier;

                    var result = await transactionBusiness.UpdateAsync(transaction);

                    logger.Debug(result);

                }
            }
            logger.Info("selam Info " + HttpContext.TraceIdentifier + " " + stopWatch.ElapsedMilliseconds + "ms");
            return Ok();
        }
    }
}
