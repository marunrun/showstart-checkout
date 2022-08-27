import React from "react";
import {Form, Select} from "antd";


const Coupon: React.FC = () => {


    return (
        <>
            <Form.Item
                label="优惠券"
                name="coupon"
            >
                <Select
                    style={{width: "100%"}}
                >

                </Select>
            </Form.Item>
        </>
    );
}

export default Coupon;
