import {RequestQo} from "../request";


export interface performerInfo {
    id: number;
    userId: number;
    name: string;
    documentType: number;
    documentTypeStr: string;
    showDocumentNumber: string;
    isSelf: number;
}

// 身份信息
export const COMMON_PERFORMER: RequestQo =
    {
        action: "/app/commonPerformer/list",
        bol: false,
        type: "REQUEST_QUERY",
        uri: "app/00000000lcvj",
        prefix: "/app/"
    }


export interface AddressInfo {
    id: number;
    address: string;
    postCode: string;
    consignee: string;
    telephone: string;
    isDefault: number;
    provinceCode: string;
    cityCode: string;
    userId: number;
    areaCode: string;
    createTime: string;
    modifyTime: string;
    provinceName: string;
    cityName: string;
}
// 收货地址
export const ADDRESS_LIST: RequestQo =
    {
        action: "/app/address/list",
        bol: false,
        type: "REQUEST_QUERY",
        uri: "app/00000000lcvj",
        prefix: "/app/"
    }
