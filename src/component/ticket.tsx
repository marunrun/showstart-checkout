import React from "react";
import {Form, Select} from "antd";

const Ticket: React.FC = () => {


    return (
        <>
            <Form.Item
                label="选票"
                name="ticket"
                rules={[{required: true, message: '请选票'}]}
            >
                <Select
                    style={{width: "100%"}}
                >

                </Select>
            </Form.Item>
        </>
    );
}

export default Ticket;
