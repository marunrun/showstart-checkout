import {RequestQo} from "../request";



    export interface ActivityInfo {
        activityId: number;
        title: string;
        activityType: number;
        siteName: string;
        city: string;
        showTime: string;
        showStartTime: any;
        avatar: string;
        price: string;
        sellIdentity: number;
        isEnd: number;
        isTour: number;
        leftDay: number;
        styles: string[];
        activityPrice: string;
        wishCount: number;
        styleIds: number[];
        isShowCollection: number;
        beginTimeConfirmed: number;
        labels: any[];
        couponTicketViews: any[];
        performerName: string;
        performerList: string[];
    }

    export interface SearchResult {
        activityInfo: ActivityInfo[];
    }



// 搜索列表
export const SEARCH: RequestQo =
    {
        action: "/app/activity/search",
        bol: false,
        type: "REQUEST_QUERY",
        uri: "app/00000000lcvj",
        prefix: "/app/"
    }


export interface Site {
    id: number;
    name: string;
    avatar: string;
    address: string;
    photo: string;
    contact: string;
    longitude: number;
    latitude: number;
    cityName: string;
    userType: number;
}

export interface UserInfo {
    id: number;
    name: string;
    avatar: string;
    userType: number;
    activityRoleType: number;
    isCollect: number;
}

export interface SessionUserInfo {
    title: string;
    sessionId: number;
    selected: number;
    isEnd: number;
    userInfos: UserInfo[];
}

export interface Group {
    id: number;
    name: string;
    avatar: string;
    size: number;
    joinCount: number;
    isJoin: number;
    nameEn: string;
    desc: string;
    joinStatus: number;
}

export interface GoodsList {
    goodsId: number;
    goodsName: string;
    goodsPoster: string;
    bindName: string;
    price: string;
    buyGroupType: number;
}

export interface StylesTopic {
    id: number;
    name: string;
}

export interface ActivityDetail {
    activityId: number;
    activityName: string;
    price: string;
    activityLevel: number;
    activityLevelName: string;
    showTime: string;
    showTimeType: number;
    avatar: string;
    album: string[];
    document: string;
    sellIdentity: number;
    activityTag: string;
    tags: string;
    banner: any[];
    music: any[];
    showLetter: boolean;
    letterCount: number;
    whetherWantTo: boolean;
    wantToNum: number;
    site: Site;
    host: any[];
    userInfos: any[];
    sessionUserInfos: SessionUserInfo[];
    url: string;
    title: string;
    showStartTime: number;
    showEndTime: number;
    group: Group;
    goodsList: GoodsList[];
    goodsNum: number;
    realName: number;
    realNameValidType: number;
    shareActivityIds: any[];
    sellTerminal: number;
    isShowCollection: number;
    serviceTemplateContent: string;
    serviceTemplateEnContent: string;
    beginTimeConfirmed: number;
    notices: any[];
    advertising: any[];
    squadStatus: number;
    sellAreaType: number;
    serviceTemplates: string[];
    stylesTopic: StylesTopic[];
    isBindHotel: number;
    coupons: any[];
    labels: any[];
}


export const ACTIVITY_DETAIL: RequestQo =
    {
        action: "/app/activity/details",
        bol: false,
        type: "REQUEST_QUERY",
        uri: "app/0h0IuB000000",
        prefix: "/app/",
        pathType: "17",
    }








