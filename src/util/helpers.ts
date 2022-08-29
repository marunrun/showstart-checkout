import CryptoJS from "crypto-js"
import {v4 as uuidv4} from 'uuid';
import base62 from "base62";

export namespace Helpers {

    export function isLogin(): boolean {
        return !!localStorage.getItem("isLogin");
    }

    export function getSign(): string {
        return localStorage.getItem("sign") ?? "";
    }

    export function getRandStr(len: number): string {
        let t = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz",
            a = t.length,
            n = "";

        for (let i = 0; i < len; i++) n += t.charAt(Math.floor(Math.random() * a));
        return n
    }

    export function getAesKey(): string {
        return localStorage.getItem("aesKey") ?? "";
    }

    export function aesEncrypt(key: string, str: string) {
        let message = CryptoJS.enc.Utf8.parse(str);
        let aKey = CryptoJS.enc.Utf8.parse(key);

        let encrypted = CryptoJS.AES.encrypt(message, aKey, {
            mode: CryptoJS.mode.ECB,
            padding: CryptoJS.pad.Pkcs7
        });
        //将结果进行base64加密
        return encrypted.ciphertext.toString(CryptoJS.enc.Base64);
    }

    export function get32RandomID(): string {
        return uuidv4().replace(/-/g, "")
    }

    export function md5(str: string): string {
        return CryptoJS.MD5(CryptoJS.enc.Utf8.parse(str)).toString()
    }

    export function getTimestamp(): number {
        return Date.parse(new Date().toString());
    }

    function convert(i2: number, str?: string) {
        let i3 = 0;
        // str 非null 非空
        if (str) {
            if (str.length < i2) {
                let sb = "";
                let length = i2 - str.length;
                while (i3 < length) {
                    i3++;
                    sb += "0";
                }
                sb += str;
                str = sb;
            }
            return str;
        }

        let sb2 = "";
        while (i3 < i2) {
            i3++;
            sb2+="0";
        }

        return sb2
    }

    export function transPath(str?: string, str2?: string): string {
        let str3 = "00";

        // 判断str 非null 非空
        if (str != null && str.length > 0) {
            let b = base62.encode(parseInt(str));
            str3 = convert(2, b);
        }

        let stringPlus = "" + str3;

        let str4 = "0000";

        if (str2 != null && str2.length > 0) {
            let b2 = base62.encode(parseInt(str2));
            str4 = convert(4, b2);
        }

        let stringPlus2 = stringPlus + str4;
        let C0 = localStorage.getItem("userId") ?? "";

        let str5 = "000000";
        // 判断C0 非null 非空
        if (C0 != null && C0.length > 0) {
            let b3 = base62.encode(parseInt(C0));
            str5 = convert(6, b3);
        }

        return stringPlus2 + str5;
    }
}

