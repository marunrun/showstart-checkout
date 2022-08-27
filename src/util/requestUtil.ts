import axios, {AxiosInstance, AxiosRequestHeaders} from "axios";
import {Helpers} from "./helpers";

let baseUrl = 'https://pro2-api.showstart.com'

const instance = axios.create({
    timeout: 10000,
    baseURL: baseUrl,
    headers: {
        "Host": "pro2-api.showstart.com",
        "User-Agent": "okhttp/4.6.0",
        "Connection": "Keep-Alive",
        "CTERMINAL": "android",
    }
})

instance.defaults.headers.post['Content-Type'] = 'application/json'

/** 添加请求拦截器 **/
instance.interceptors.request.use(config => {

    // 添加默认一些header头
    if (config.headers) {
        config.headers['CUUSERREF'] = Helpers.md5(Helpers.get32RandomID());
        config.headers["CUSUT"] = Helpers.getSign();
        config.headers["CUSYSTIME"] = Helpers.getTimestamp();
    }

    return config
}, error => {
    // 对请求错误做些什么
    console.log(error)
    return Promise.reject(error)
})


export const post = (url: string, data: string, config = {}) => {
    return instance({
            method: 'post',
            url,
            data,
            ...config
        }).then(response => {
            console.log(response.data);
           return response.data
        }).catch(error => {
        return Promise.reject(error);
        })
}

export const get = (url: string, params: string, config = {}) => {
    return new Promise((resolve, reject) => {
        instance({
            method: 'get',
            url,
            params,
            ...config
        }).then(response => {
            resolve(response)
        }).catch(error => {
            reject(error)
        })
    })
}
