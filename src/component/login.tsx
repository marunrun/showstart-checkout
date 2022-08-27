import React from "react";
import {Button, Checkbox, Form, Input} from "antd";

class LoginForm extends React.Component<any, any> {

    onFinish = (values: any) => {
        console.log('Success:', values);
    };

    render() {

        return (
            <Form
                size="small"
                initialValues={{
                    remember: true,
                }}
                onFinish={this.onFinish}
                autoComplete="off"
            >
                <Form.Item
                    label="账号"
                    name="username"
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
                    <Input.Password/>
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
        );
    }
}

export default LoginForm
