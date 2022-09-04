import {RequestQo} from "../request";


// 下单
export const ORDER_ORDER: RequestQo =
    {
        action: "/order/order",
        bol: false,
        type: "REQUEST_QUERY",
        uri: "appnj/00000000lcvj",
        prefix: "/appnj/"
    };


export interface OrderPlaceGoodsBean {
    cartId: string
    goodsId: number
    goodsType: number
    num: number
    price: number
    skuId: string
    skuType: number
}

// 下单结果
export const ORDER_RESULT: RequestQo =
    {
        action: "/order/getCoreOrderResult",
        bol: false,
        type: "REQUEST_QUERY",
        uri: "appnj/00000000lcvj",
        pathType: "2",
        prefix: "/appnj/",
    };



