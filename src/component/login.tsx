import React from "react";
import {Button, Form, Input, message} from "antd";
import {post} from "../util/http";
import {ApiParams} from "../network/apiParams";
import {store} from "../constant/store";
import {LOGIN_PWD} from "../network/api/login";


export interface LoginProps {
    afterLoginSuccess: () => void
}


const LoginForm: React.FC<LoginProps> = (props) => {

    function onFinish(values: any) {

        localStorage.setItem(store.mobile, values.mobile)
        localStorage.setItem(store.password, values.password)

        let apiParams = new ApiParams();
        apiParams.set("name", values.mobile)
        apiParams.set("password", values.password)
        post(LOGIN_PWD, apiParams, (res) => {
            message.success("登录成功")
            localStorage.setItem(store.userSign, res.sign)
            localStorage.setItem(store.userId, res.userId)
            props.afterLoginSuccess()
        })
    }

    return <>
        <Form
            size="small"
            initialValues={{
                mobile: localStorage.getItem(store.mobile),
                password: localStorage.getItem(store.password)
            }}
            onFinish={onFinish}
            autoComplete="off"
        >
            <Form.Item
                label="账号"
                name="mobile"
                rules={[
                    {
                        required: true,
                        message: '请输入账号',
                    },
                ]}
            >
                <Input/>
            </Form.Item>

            <Form.Item
                label="密码"
                name="password"
                rules={[
                    {
                        required: true,
                        message: '请输入密码',
                    },
                ]}
            >
                <Input/>
            </Form.Item>

            <Form.Item
                wrapperCol={{
                    offset: 2,
                    span: 16,
                }}
            >
                <Button type="primary" htmlType="submit">
                    登录
                </Button>
            </Form.Item>
        </Form>
    </>

}

export default LoginForm
