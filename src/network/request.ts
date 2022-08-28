
// 定义一个新的类型为RequestQo
import {ApiParams, RequestType} from "./apiParams";

export interface RequestQo {
    action: string;
    bol: boolean;
    type: RequestType;
    uri: string;
    pathType?: string;
    prefix?: string;
    sessionId?: string;
}

export function reqToParams(req : RequestQo)
{
    var apiParams = new ApiParams();
    // apiParams.getPostParams()
}



// token生成
export const MAKE_TOKEN: RequestQo =
    {
        action: "/common/user/maketoken",
        bol: true,
        type: "REQUEST_QUERY",
        uri: "app/00000000lcvj"
    }

//密码登录
export const LOGIN_PWD: RequestQo =
    {
        action: "/app/user/login",
        bol: false,
        type: "REQUEST_QUERY",
        uri: "app/000000000000"
    };