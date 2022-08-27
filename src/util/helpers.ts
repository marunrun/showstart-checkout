import CryptoJS from "crypto-js"
import { v4 as uuidv4 } from 'uuid';

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

        let encrypted = CryptoJS.AES.encrypt(message,aKey,{
            mode:CryptoJS.mode.ECB,
            padding:CryptoJS.pad.Pkcs7
        });
        //将结果进行base64加密
        return encrypted.ciphertext.toString(CryptoJS.enc.Base64);
    }

    export  function get32RandomID() : string
    {
        return uuidv4().replace(/-/g,"")
    }

    export function md5(str : string) : string
    {
        return CryptoJS.MD5(CryptoJS.enc.Utf8.parse(str)).toString()
    }

    export function getTimestamp() :number
    {
        return Date.parse(new Date().toString());
    }


}


