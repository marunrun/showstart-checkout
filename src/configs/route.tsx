import { HomeOutlined} from '@ant-design/icons';
import Home from "../pages/home";
import {Route} from "@ant-design/pro-layout/lib/typings";


const route : Route  = {
        path: '/',
        routes: [
            {
                path: '/home',
                pathname: '/home',
                name: '主页',
                icon: <HomeOutlined /> ,
                component: <Home/>,
            }
        ],
};

export default route;
