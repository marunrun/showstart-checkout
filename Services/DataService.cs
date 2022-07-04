﻿using checkout.Constants;
using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Exceptions;
using checkout.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace checkout.Services
{
    public static class DataService
    {
        /**
         * 演出搜索
         **/
        public static async Task<List<ActivityInfoVo>> GetSearchResults(string keyword ,int pageNo)
        {
            SearchQo searchQo = new SearchQo
            {
                keyword = keyword,
                pageNo = pageNo,
                pageSize = 20
            };


            var res = await RequestUtil.post(Urls.SEARCH, searchQo);

            var response = JsonSerializer.Deserialize<Result<ActivityInfoList>>(res);

            if (!response.isSuccess()) {
                throw new BusinessException("搜索失败:"+response.msg);

            }

            return response.result.activityInfo;

        }

        public static async void GetTicketList(string activityId,Action<TicketListVo> callback)
        {
            TicketListQo activityDetailQo = new TicketListQo
            {
                activityId = activityId
            };

            var res = await RequestUtil.post(Urls.TICKET_LIST, activityDetailQo);

            var response = JsonSerializer.Deserialize<Result<TicketListVo>>(res);


            if (!response.isSuccess())
            {
                throw new BusinessException("演出票搜索失败:" + response.msg);

            }

            callback(response.result);
        }
    }
}