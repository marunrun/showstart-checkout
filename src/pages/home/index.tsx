import React from "react";
import {PageContainer} from "@ant-design/pro-layout";
import {Card} from "antd";
import LoginForm from "../../component/login";


const Home: React.FC = () => {

    return (
       <>

           <Card>
            <LoginForm/>
           </Card>
       </>
    );
}

export default Home