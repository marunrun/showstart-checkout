import {RequestQo} from "../request";


export interface TicketInfo {
    ticketId: string;
    ticketType: string;
    sellingPrice: number;
    costPrice: string;
    ticketNum: number;
    validateType: number;
    time: string;
    instruction: string;
    countdown: number;
    remainTicket: number;
    saleStatus: number;
    activityId: number;
    goodType: number;
    telephone: string;
    areaCode: string;
    limitBuyNum: number;
    canBuyNum: number;
    cityName: string;
    unPayOrderNum: number;
    type: number;
    buyType: number;
    canAddGoods: number;
    ticketRecordStatus: number;
    startSellNoticeStatus: number;
    showRuleTip: boolean;
    startTime: any;
    showTime: string;
    memberNum: number;
}

export interface Session {
    sessionName: string;
    sessionId: number;
    isConfirmedStartTime: number;
    ticketList: TicketInfo[];
}

export interface TicketListResult {
    sessions: Session[];
    showTime: string;
}


// 选票
export const TICKET_LIST: RequestQo =
    {
        action: "/app/activity/V2/ticket/list",
        bol: false,
        type: "REQUEST_QUERY",
        uri: "app/0g0IeO00j2rN",
        prefix: "/app/",
        pathType: "16",
    }
