import {http} from "@tauri-apps/api";
import {getUri, MAKE_TOKEN, RequestQo} from "../network/request";
import {Body, fetch, ResponseType} from "@tauri-apps/api/http";
import {Helpers} from "./helpers";
import {ApiParams, RequestParams} from "../network/apiParams";
import {response, state} from "../network/response";
import {message as antdMsg} from "antd"
import {store} from "../constant/store";

let baseUrl = 'https://pro2-api.showstart.com'



const uuid = Helpers.get32RandomID();
let  tokenInit = false;

post(MAKE_TOKEN, new ApiParams(), (res) => {
    localStorage.setItem(store.token, res)
    tokenInit = true;
})


export function post(requestQo: RequestQo, data: ApiParams, callback: ((res: any) => void), sessionId?: string) {

    if (requestQo !== MAKE_TOKEN && !tokenInit) {
        setTimeout(() => {
            post(requestQo, data, callback, sessionId)
        }, 100)
        return
    }

    let request: RequestParams = {
        action: requestQo.action,
        z: requestQo.bol,
        type: requestQo.type,
    }

    let postParams = data.getPostParams(request);

    requestQo.sessionId = sessionId;
    let headers = {
        "Host": "pro2-api.showstart.com",
        "User-Agent": "okhttp/4.6.0",
        "Connection": "Keep-Alive",
        "CTERMINAL": "android",
        'CUUSERREF': Helpers.md5(uuid),
        "CUSUT": Helpers.getSign(),
        "CUSYSTIME": Helpers.getTimestamp().toString(),
    }
    console.log(request);
    fetch(baseUrl + getUri(requestQo), {
        body: Body.json(postParams),
        headers,
        method: 'POST',
        responseType: ResponseType.JSON,
    }).then(res => {

        let response = res.data as response;
        console.log(response)

        if (response.state == state.user_not_login || response.state == state.user_login_again || response.state == state.user_ref_login_again || response.state == state.user_token_login_again) {
            antdMsg.error("登录已过期,请重新登录")
            return;
        } else if (response.state == state.user_other_login) {
            antdMsg.error(response.msg ?? "登录已过期,请重新登录")
            return;
        } else if (response.state != "1") {
            antdMsg.error(response.msg ? response.msg : "网络错误")
            return;
        }

        callback(response.result);
    })


}

