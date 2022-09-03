import React from "react";
import LoginForm from "../../component/login";
import {ProCard} from "@ant-design/pro-card";
import ChooseUser from "../../component/chooseUser";


const userChange = (user: string) => {

}

const Home: React.FC = () => {

    return (
        <>
            <ProCard style={{marginBlockStart: 8}} gutter={8} title="用户信息">
                <ProCard>
                    <LoginForm/>
                </ProCard>
                <ProCard>
                    <ChooseUser onChange={userChange}/>
                </ProCard>
            </ProCard>
        </>
    );
}

export default Home
