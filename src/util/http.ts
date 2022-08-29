import {http} from "@tauri-apps/api";
import {getUri, RequestQo} from "../network/request";
import {Body} from "@tauri-apps/api/http";
import {Helpers} from "./helpers";
import {ApiParams, RequestParams} from "../network/apiParams";

let baseUrl = 'https://pro2-api.showstart.com'


let client = await http.getClient();


export function post(requestQo: RequestQo, data: object, callback: ((res: string) => void), sessionId?: string) {

    let apiParams = new ApiParams();
    let request: RequestParams = {
        action: requestQo.action,
        z: requestQo.bol,
        type: requestQo.type
    }

    let postParams = apiParams.getPostParams(request);
    console.log(requestQo);

    client.post(baseUrl + getUri(requestQo), Body.json(postParams), {
        headers: {
            "Host": "pro2-api.showstart.com",
            "User-Agent": "okhttp/4.6.0",
            "Connection": "Keep-Alive",
            "CTERMINAL": "android",
            'CUUSERREF': Helpers.md5(Helpers.get32RandomID()),
            "CUSUT": Helpers.getSign(),
            "CUSYSTIME": Helpers.getTimestamp().toString(),
        }
    }).then(res => {callback(res.data as string)})


}

