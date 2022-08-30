import {Config} from "../constant/config";
import {Helpers} from "../util/helpers";
import {Parameter, RealParameter} from "./Parameter";


export type RequestType = "REQUEST_BODY" | "REQUEST_QUERY"

export interface RequestParams {
    action: string;
    z: boolean;
    type: RequestType;
}


export class ApiParams extends Map<String, Object> {

    public getPostParams(requestParams: RequestParams): RealParameter {

        let parameter = this.getParameter(requestParams.action);
        let requestJson: string

        if (requestParams.type === "REQUEST_BODY") {
            requestJson = JSON.stringify({
                ...parameter,
                body: this._toObj()
            })
        } else {
            requestJson = JSON.stringify({
                ...parameter,
                query: this._toObj()
            })
        }

        let arukey = Helpers.getAruKey()
        console.log(arukey)
        arukey = arukey.length < 1 ? Config.aruKey : arukey
        console.log(arukey);
        let dataKey = Helpers.getToken()
        if (requestParams.z) {
            dataKey = arukey
        }

        return {
            appid: Config.appid,
            terminal: Config.terminal,
            version: Config.appVersion,
            aru: Helpers.aesEncrypt(arukey, requestParams.action),
            data: Helpers.aesEncrypt(dataKey, requestJson),
            sign: Helpers.md5(requestJson)
        };
    }

    /**
     *  获取公用的数据
     * @param action
     * @protected
     */
    protected getParameter(action: string): Parameter {
        return {
            action: action,
            qtime: Helpers.getTimestamp(),
            deviceName: Config.deviceName,
            ranstr: Helpers.getRandStr(8),
            sysVersion: Config.sysVersion
        }
    }

    /**
     * 将当前map 转换成object
     * @protected
     */
    protected _toObj() {
        let obj = Object.create(null);

        const iterator = this.keys();
        for (let i = 0; i < this.size; i++) {
            const key = iterator.next().value;
            obj[key] = this.get(key);
        }
        return obj;
    }

}
