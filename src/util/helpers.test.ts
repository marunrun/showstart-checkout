import {Helpers} from "./helpers";

test("aes test",function () {
    const aesEncrypt1 = Helpers.aesEncrypt("fGTKGj1VVAYaNIEu","bcad123");
    expect(aesEncrypt1).toEqual("NJ64usPM8nJMAiY6UWfWrQ==")
})

test("32uuid",function (){
    let uid = Helpers.get32RandomID();
    expect(uid.length).toEqual(32)
})

test("md5",function (){
    let res = Helpers.md5("1231231");
    expect(res).toEqual("8d4646eb2d7067126eb08adb0672f7bb")
});
