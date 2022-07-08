using checkout.Constants;
using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Exceptions;
using checkout.Helper;
using Newtonsoft.Json;
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

            var response = JsonConvert.DeserializeObject<Result<ActivityInfoList>>(res);

            if (!response.isSuccess()) {
                throw new BusinessException("搜索失败:"+response.msg);

            }

            return response.result.activityInfo;

        }

        public static async void GetTicketList(string activityId,Action<Result<TicketListVo>> callback)
        {
            TicketListQo activityDetailQo = new TicketListQo
            {
                activityId = activityId
            };

            var res = await RequestUtil.post(Urls.TICKET_LIST, activityDetailQo);

            var response = JsonConvert.DeserializeObject<Result<TicketListVo>>(res);


            callback(response);
        }

        public static async void getPerfomer(Action<Result<List<UserIdInfo>>> callback)
        {
            RequestUtil.post(Urls.COMMON_PERFORMER, new object(), (res) =>
            {
                Result<List<UserIdInfo>> result = JsonConvert.DeserializeObject<Result<List<UserIdInfo>>>(res);

                callback(result);
            });
        }

        public static async void getAddress(Action<Result<List<AddressInfo>>> callback)
        {
            AddressQo addressQo = new AddressQo
            {
                pageNo = 0,
                pageSize = 10,
            };

            RequestUtil.post(Urls.ADDRESS_LIST, addressQo, (res) =>
            {
                Result<List<AddressInfo>> result = JsonConvert.DeserializeObject<Result<List<AddressInfo>>>(res);
                callback(result);
            });
        }
    }
}
