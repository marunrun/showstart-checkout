using checkout.Constants;
using checkout.Entity;
using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Exceptions;
using checkout.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Services
{
    internal class OrderService
    {
        public static void buyNow(BuyTicketDto buyTicketDto, Action<Result<OrderOrderVo>> callback)
        {
            var orderQo = getOrderQo(buyTicketDto);

            var ticket = orderQo.ticket;
            var apiParams = orderQo.apiParams;

            RequestUtil.post(Urls.ORDER_ORDER, apiParams, ((res) =>
            {
                callback(JsonConvert.DeserializeObject<Result<OrderOrderVo>>(res));

            }), ticket.activityId);

        }



        // 获取下单参数

        private static OrderQo getOrderQo(BuyTicketDto buyTicketDto)
        {
            TicketListItem ticket = buyTicketDto.ticket;
            ActivityInfoVo activity = buyTicketDto.activity;
            AddressInfo addressInfo = buyTicketDto.addressInfo;
            CouponInfoVo couponInfo = buyTicketDto.couponInfo;
            int buyNum = buyTicketDto.buyNum;


            var amountPayable = ticket.sellingPrice * buyNum;
            // 优惠券
            if (couponInfo != null)
            {
                amountPayable = amountPayable - couponInfo.price;
            }

            List<OrderPlaceGoodsBean> lists = new List<OrderPlaceGoodsBean>();
            OrderPlaceGoodsBean orderPlaceGoodsBean = new OrderPlaceGoodsBean();
            orderPlaceGoodsBean.goodsType = 1;
            orderPlaceGoodsBean.skuType = 1;
            if (ticket.type == 2 || ticket.type == 3)
            {
                orderPlaceGoodsBean.skuType = ticket.type;
            }

            orderPlaceGoodsBean.num = buyNum;
            orderPlaceGoodsBean.goodsId = ticket.activityId;
            orderPlaceGoodsBean.skuId = ticket.ticketId;
            orderPlaceGoodsBean.cartId = "";
            orderPlaceGoodsBean.price = ticket.sellingPrice.ToString();
            lists.Add(orderPlaceGoodsBean);

            Dictionary<string, object> apiParams = new Dictionary<string, object>
            {
                //{"telephone",userService.tel},
                {"customerName",addressInfo.consignee},
                // 实际支付金额
                {"amountPayable",amountPayable },
                // 总价
                {"totalAmount",ticket.sellingPrice * buyNum },
                // 折扣
                {"discount",couponInfo == null ? 0 :couponInfo.price},
                {"source","0"},
                {"telephone",UserService.getMobile() },
                // 订单详情
                {"orderDetails",lists},
                // 地区
                {"areaCode","86_CN"},
                {"customerRemark",""},
                {"longitude",0},
                {"latitude",0},
            };

            // 电子票 or 实体票
            if (ticket.type == 2)
            {
                apiParams.Add("provinceName", addressInfo.provinceName);
                apiParams.Add("cityName", addressInfo.cityName);
                apiParams.Add("address", addressInfo.address);
            }

            if (couponInfo != null)
            {
                apiParams.Add("couponId", couponInfo.id);
            }


            // 实名
            if (ticket.buyType == 2)
            {

                if (buyTicketDto.userList.Count != buyNum)
                {
                    throw new BusinessException("观影人数量选择错误 , 必须与购票数量一致");
                }

                List<long> perfomerIdList = new List<long> { };

                for (int i = 0; i < buyTicketDto.userList.Count; i++)
                {
                    perfomerIdList.Add(buyTicketDto.userList[i].id);

                }

                apiParams.Add("commonPerfomerIds", perfomerIdList);
            }

            return new OrderQo()
            {
                ticket = ticket,
                activityInfo = activity,
                apiParams = apiParams
            };
        }
    }
}
