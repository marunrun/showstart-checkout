import React from "react";
import LoginForm from "../../component/login";
import {ProCard} from "@ant-design/pro-card";
import ChooseUser from "../../component/chooseUser";
import Search from "../../component/search";
import Ticket from "../../component/ticket";
import Buttons from "../../component/buttons";
import {Form, message, notification} from "antd";
import {useForm} from "antd/es/form/Form";
import {ApiParams} from "../../network/apiParams";
import {AddressInfo, performerInfo} from "../../network/api/userInfo";
import {TICKET_LIST, TicketInfo, TicketListResult} from "../../network/api/ticket";
import {store} from "../../constant/store";
import {ORDER_ORDER, ORDER_RESULT, OrderPlaceGoodsBean} from "../../network/api/order";
import {post} from "../../util/http";


const Home: React.FC = () => {



    const [activityId, setActivityId] = React.useState<number>();
    const [ticketInfo, setTicketInfo] = React.useState<TicketInfo>();
    const [performerInfo, setPerformerInfo] = React.useState<performerInfo[]>([]);
    const [address, setAddress] = React.useState<AddressInfo>();


    // 捡漏
    const [pickupEnable, setPickupEnable] = React.useState<boolean>(false);
    const [pickupTimer, setPickupTimer] = React.useState<number>(0);


    // 定时购票
    const [buyTimer, setBuyTimer] = React.useState<number>(0);
    const [buyTimerEnable, setBuyTimerEnable] = React.useState<boolean>(false);

    const [form] = useForm()


    // 收货地址
    function addressChange(address: AddressInfo) {
        setAddress(address)
    }

    // 观影人列表
    function performerChange(performers: performerInfo[]) {
        setPerformerInfo(performers)
    }

    // 演出
    function activityChange(activityId: number) {
        setActivityId(activityId)
    }

    // 选票
    function ticketChange(ticketInfo: TicketInfo) {
        setTicketInfo(ticketInfo)
    }

    // 下单信息
    const getOrderRequest = (values: any): ApiParams | void => {
        let apiParams = new ApiParams();


        if (!ticketInfo) {
            message.error("选票错误")
            return;
        }

        //todo 减去优惠的金额
        let amountPayable = (ticketInfo.sellingPrice) * values.buyCount

        let orderList: OrderPlaceGoodsBean[] = [];

        let orderPlaceGoodsBean: OrderPlaceGoodsBean = {
            goodsType: 1,
            skuType: 1,
            num: values.buyCount,
            goodsId: ticketInfo.activityId,
            skuId: ticketInfo.ticketId,
            cartId: "",
            price: ticketInfo.sellingPrice,
        }
        orderList.push(orderPlaceGoodsBean)

        if (ticketInfo.type == 2 || ticketInfo.type == 3) {
            orderPlaceGoodsBean.skuType = ticketInfo.type
        }


        apiParams.set("customerName", address?.consignee ?? "")
        apiParams.set("amountPayable", amountPayable)
        apiParams.set("totalAmount", (ticketInfo!!.sellingPrice) * values.buyCount)
        apiParams.set("source", 0)
        apiParams.set("telephone", localStorage.getItem(store.mobile) ?? "")
        apiParams.set("orderDetails", orderList)
        apiParams.set("areaCode", "86_CN")
        apiParams.set("customerRemark", "")
        apiParams.set("longitude", 0)
        apiParams.set("latitude", 0)

        // 电子票 or 实体票
        if (ticketInfo.type == 2) {
            if (!address) {
                message.error("实体票请选择收货地址")
                return;
            }

            apiParams.set("provinceName", address.provinceName);
            apiParams.set("cityName", address.cityName);
            apiParams.set("address", address.address);
        }

        // 实名
        if (ticketInfo.buyType == 2) {

            let performerIds = performerInfo.map((item) => {
                return item.id
            })

            if (performerIds.length != values.buyCount) {
                message.error("观影人数量选择错误 , 必须与购票数量一致")
                return;
            }

            apiParams.set("commonPerfomerIds", performerIds);
        }

        return apiParams
    }


    // 立即购买
    function buyNow() {
        form.validateFields()
            .then((values) => {

                let orderRequest = getOrderRequest(values);
                if (!orderRequest) {
                    return;
                }

                post(ORDER_ORDER, orderRequest, (data) => {
                    console.log(data)
                    let orderJobKey = data.orderJobKey


                    // 查询下单结果
                    let resultQuery = new ApiParams();
                    resultQuery.set("orderJobKey", orderJobKey)

                    post(ORDER_RESULT, resultQuery, function (data) {
                        if (data == "pending") {
                            message.error("下单失败 " + data)
                            return;
                        }
                        notification.success({message: "抢票成功：",description : JSON.stringify(data)})
                        if (pickupTimer) {
                            clearInterval(pickupTimer)
                            setPickupTimer(0)
                        }
                    });

                }, ticketInfo?.ticketId)

            })
            .catch(() => {
            })
        ;
    }

    // 捡漏
    function buyPickup() {
        form.validateFields()
            .then((values) => {

                if (!ticketInfo) {
                    message.error("选票错误")
                    return;
                }

                let orderRequest = getOrderRequest(values);
                if (!orderRequest) {
                    return;
                }

                if (pickupTimer) {
                    // 清除定时器
                    clearInterval(pickupTimer)
                    setPickupTimer(0)
                    setPickupEnable(false)
                    return
                }


                setPickupEnable(true)

                // 一秒的定时器
                let newTimer = setInterval(() => {
                    let apiParams = new ApiParams();

                    apiParams.set("activityId", ticketInfo.activityId)

                    post(TICKET_LIST, apiParams, function (data: TicketListResult) {
                        data.sessions.forEach((session) => {
                            session.ticketList.forEach((ticket) => {
                                if (ticket.ticketId == ticketInfo.ticketId && ticket.saleStatus == 1 && ticket.remainTicket > 0) {
                                    buyNow();
                                    return;
                                }
                            });
                        })
                    });

                }, 1000)

                setPickupTimer(newTimer)
            })
    }



    // 定时购票
    function buyTicket() {

        form.validateFields()
            .then((values) => {

                if (!ticketInfo) {
                    message.error("选票错误")
                    return;
                }

                let orderRequest = getOrderRequest(values);
                if (!orderRequest) {
                    return;
                }

                if (buyTimer) {
                    // 清除定时器
                    clearInterval(buyTimer)
                    setBuyTimer(0)
                    setBuyTimerEnable(false)
                    return
                }


                setBuyTimerEnable(true)

                let startTime = ticketInfo.startTime;


                // 一秒的定时器
                let newTimer = setTimeout(() => {
                    setBuyTimer(0)
                    setBuyTimerEnable(false)
                    buyNow()
                }, startTime - Date.now() - 100)

                setBuyTimer(newTimer)
            })
    }

    return (
        <>
            <ProCard gutter={8} title="用户信息">
                <ProCard>
                    <LoginForm/>
                </ProCard>
                <ProCard>
                    <ChooseUser onAddressChange={addressChange} onPerformerChange={performerChange}/>
                </ProCard>
            </ProCard>
            <ProCard style={{marginBlockStart: 8}} gutter={8} title="选择演出">
                <Form
                    initialValues={{
                        buyCount: 1
                    }}
                    form={form}
                >
                    <Search activityChange={activityChange}/>
                    <Ticket ticketChange={ticketChange} form={form} activityId={activityId}/>
                    <Buttons buyTicket={buyTicket}
                             buyNow={buyNow}
                             buyPickup={buyPickup}
                             pickEnable={pickupEnable}
                             ticketEnable={buyTimerEnable}
                    />
                </Form>

            </ProCard>


        </>
    );
}

export default Home
