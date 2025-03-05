using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using CustomerOrderSystem.Application.Services;
using CustomerOrderSystem.Application.DTOs;
using CustomerOrderSystem.Domain.Entities;

namespace CustomerOrderSystem.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    // 訂單控制器，負責處理 HTTP 請求
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;  // 訂單服務

        // 建構函式，注入訂單服務
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // 創建訂單的 API 端點
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            // 使用 ToDomain() 來轉換 Items
            List<OrderItem> orderItems = request.Items.Select(itemDto => itemDto.ToDomain()).ToList();

            // 呼叫服務層創建訂單
            var orderId = _orderService.CreateOrder(request.CustomerId, orderItems);  // 傳遞轉換後的 OrderItem 列表

            return CreatedAtAction(nameof(GetOrder), new { orderId }, null);  // 返回創建的訂單 ID
        }

        // 根據訂單 ID 查找訂單
        [HttpGet("{orderId}")]
        public IActionResult GetOrder(Guid orderId)
        {
            var order = _orderService.FindById(orderId);  // 查找訂單
            return order != null ? Ok(order) : NotFound();  // 返回訂單或 404
        }

        // 付款訂單的 API 端點
        [HttpPost("{orderId}/pay")]
        public IActionResult PayOrder(Guid orderId)
        {
            _orderService.PayOrder(orderId);  // 呼叫服務層進行付款
            return NoContent();  // 無內容回應
        }

        // 發貨訂單的 API 端點
        [HttpPost("{orderId}/ship")]
        public IActionResult ShipOrder(Guid orderId)
        {
            _orderService.ShipOrder(orderId);  // 呼叫服務層進行發貨
            return NoContent();  // 無內容回應
        }

    }

}
