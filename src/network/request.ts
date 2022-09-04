// 定义一个新的类型为RequestQo
import {RequestType} from "./apiParams";
import {Helpers} from "../util/helpers";

export interface RequestQo {
    action: string;
    bol: boolean;
    type: RequestType;
    uri: string;
    pathType?: string;
    prefix: string;
    sessionId?: string;
}

export function getUri(request : RequestQo)
{
    let uri =  request.prefix + Helpers.transPath(request.pathType, request.sessionId);

    console.log(uri);
    return uri;
}

// token生成
export const MAKE_TOKEN: RequestQo =
    {
        action: "/common/user/maketoken",
        bol: true,
        type: "REQUEST_QUERY",
        uri: "app/00000000lcvj",
        prefix : "/app/"
    }

